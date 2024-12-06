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
    
    public async Task<Movie> GetMovieById(int movieId)
    {
        return await _movieRepository.GetMovieById(movieId);
    }
    
    public async Task<bool> AddMovie(Movie movie)
    {
        if (movie == null)
        {
            throw new ArgumentNullException(nameof(movie));
        }

        await _movieRepository.AddMovie(movie);

        return true; 
    }
    
    public async Task DeleteMovie(int movieId)
    {
        await _movieRepository.DeleteMovie(movieId);
    }
}
