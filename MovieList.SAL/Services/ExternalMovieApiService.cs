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

            var query = $"https://api.themoviedb.org/3/discover/movie?query={Uri.EscapeDataString(movieName)}&api_key={apiKey}";

            var allMovies = new List<Movie>();
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

                var externalApiResponse = await response.Content.ReadFromJsonAsync<ExternalApiResponse>();

                if (externalApiResponse?.Results == null || !externalApiResponse.Results.Any())
                {
                    break;
                }

                foreach (var result in externalApiResponse.Results)
                {
                    allMovies.Add(new Movie
                    {
                        TmdbId = result.Id, 
                        Name = result.Title,
                        Description = result.Overview,
                        PictureUrl = !string.IsNullOrEmpty(result.PosterPath)
                            ? $"https://image.tmdb.org/t/p/w500{result.PosterPath}"
                            : null,
                        ReleaseDate = DateTime.TryParse(result.ReleaseDate, out var releaseDate) ? releaseDate : (DateTime?)null,
                        VoteAverage = result.VoteAverage,
                        VoteCount = result.VoteCount,
                        Genres = result.GenreIds,
                        OriginalLanguage = result.OriginalLanguage,
                        BackdropPath = !string.IsNullOrEmpty(result.BackdropPath)
                            ? $"https://image.tmdb.org/t/p/w500{result.BackdropPath}"
                            : null,
                        MovieLists = new List<Common.MovieList>(), 
                    });
                }

                morePages = externalApiResponse.Page < externalApiResponse.TotalPages;
                page++;
            }

            return allMovies;
        }
    }
}
