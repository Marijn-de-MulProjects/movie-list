using System.Net.Http.Json;
using MovieList.Common;

namespace MovieList.SAL.Services
{
    public class ExternalMovieApiService : IExternalMovieApiService
    {
        private readonly HttpClient _httpClient;

        public ExternalMovieApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Movie>> SearchMovieByName(string movieName)
        {
            var apiKey = Environment.GetEnvironmentVariable("TMDB_API_KEY");
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new Exception("TMDB_API_KEY is not set in the environment variables.");
            }

            var allMovies = new List<Movie>();

            await FetchMoviesOrTvShows(allMovies, movieName, apiKey, isMovie: true);
            await FetchMoviesOrTvShows(allMovies, movieName, apiKey, isMovie: false);

            return allMovies;
        }

        private async Task FetchMoviesOrTvShows(List<Movie> allMovies, string movieName, string apiKey, bool isMovie)
        {
            var query = isMovie
                ? $"https://api.themoviedb.org/3/search/movie?query={Uri.EscapeDataString(movieName)}&api_key={apiKey}"
                : $"https://api.themoviedb.org/3/search/tv?query={Uri.EscapeDataString(movieName)}&api_key={apiKey}";

            var page = 1;
            bool morePages = true;

            while (morePages)
            {
                var paginatedQuery = $"{query}&page={page}";
                var response = await _httpClient.GetAsync(paginatedQuery);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"External API returned error: {response.StatusCode}");
                }

                var rawResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"API Response Body (Page {page}): {rawResponse}");

                if (isMovie)
                {
                    var externalMovieResponse = await response.Content.ReadFromJsonAsync<ExternalApiResponseMovie>();

                    if (externalMovieResponse?.Results == null || !externalMovieResponse.Results.Any())
                    {
                        Console.WriteLine($"No results for movies on page {page}");
                        break;
                    }

                    foreach (var result in externalMovieResponse.Results)
                    {
                        var posterUrl = GetImageUrl(result.PosterPath);
                        var backdropUrl = GetImageUrl(result.BackdropPath);

                        DateTime? releaseDate = TryParseDate(result.ReleaseDate);

                        allMovies.Add(new Movie
                        {
                            TmdbId = result.Id,
                            Name = result.Title ?? "Unknown Title",
                            Description = string.IsNullOrWhiteSpace(result.Overview)
                                ? "No description available."
                                : result.Overview,
                            PictureUrl = posterUrl,
                            ReleaseDate = releaseDate,
                            VoteAverage = result.VoteAverage > 0 ? result.VoteAverage : 0,
                            VoteCount = result.VoteCount > 0 ? result.VoteCount : 0,
                            Genres = result.GenreIds ?? new List<int>(),
                            OriginalLanguage = string.IsNullOrWhiteSpace(result.OriginalLanguage)
                                ? "Unknown"
                                : result.OriginalLanguage,
                            BackdropPath = backdropUrl,
                            MovieLists = new List<Common.MovieList>(),
                        });
                    }

                    morePages = externalMovieResponse.Page < externalMovieResponse.TotalPages;
                }
                else
                {
                    var externalTvResponse = await response.Content.ReadFromJsonAsync<ExternalTvApiResponse>();

                    if (externalTvResponse?.Results == null || !externalTvResponse.Results.Any())
                    {
                        Console.WriteLine($"No results for TV shows on page {page}");
                        break;
                    }

                    foreach (var result in externalTvResponse.Results)
                    {
                        var posterUrl = GetImageUrl(result.PosterPath);
                        var backdropUrl = GetImageUrl(result.BackdropPath);

                        DateTime? releaseDate = TryParseDate(result.FirstAirDate);

                        allMovies.Add(new Movie
                        {
                            TmdbId = result.Id,
                            Name = result.Name ?? "Unknown Title",
                            Description = string.IsNullOrWhiteSpace(result.Overview)
                                ? "No description available."
                                : result.Overview,
                            PictureUrl = posterUrl, 
                            ReleaseDate = releaseDate, 
                            VoteAverage = result.VoteAverage > 0 ? result.VoteAverage : 0, 
                            VoteCount = result.VoteCount > 0 ? result.VoteCount : 0, 
                            Genres = result.GenreIds ?? new List<int>(), 
                            OriginalLanguage = string.IsNullOrWhiteSpace(result.OriginalLanguage)
                                ? "Unknown"
                                : result.OriginalLanguage,
                            BackdropPath = backdropUrl,
                            MovieLists = new List<Common.MovieList>(), 
                        });
                    }

                    morePages = externalTvResponse.Page < externalTvResponse.TotalPages;
                }

                page++;
            }
        }

        private string GetImageUrl(string imagePath)
        {
            return !string.IsNullOrEmpty(imagePath)
                ? $"https://image.tmdb.org/t/p/w500{imagePath}"
                : "https://via.placeholder.com/500x750.png?text=No+Image";
        } 

        private DateTime? TryParseDate(string dateString)
        {
            if (DateTime.TryParse(dateString, out var parsedDate))
            {
                return parsedDate;
            }

            return null; 
        }
    }
}
