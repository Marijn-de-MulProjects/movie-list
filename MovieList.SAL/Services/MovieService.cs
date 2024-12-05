using MovieList.Common;

namespace MovieList.SAL.Services;

public class MovieService
{
    private readonly IMovieRepository _movieRepository;
    private readonly IExternalMovieApiService _externalMovieApiService;

    public MovieService(IMovieRepository movieRepository, IExternalMovieApiService externalMovieApiService)
    {
        _movieRepository = movieRepository;
        _externalMovieApiService = externalMovieApiService;
    }

    public async Task<IEnumerable<Movie>> SearchMovie(string movieName)
    {
        var cachedMovies = await _movieRepository.SearchMoviesByName(movieName);

        if (cachedMovies.Any())
        {
            return cachedMovies;
        }

        var externalMovies = await _externalMovieApiService.SearchMovieByName(movieName);

        if (externalMovies == null || !externalMovies.Any())
        {
            return Enumerable.Empty<Movie>();
        }

        foreach (var movie in externalMovies)
        {
            await _movieRepository.AddMovie(movie);
        }

        return externalMovies;
    }
}
