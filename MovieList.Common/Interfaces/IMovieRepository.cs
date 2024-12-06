namespace MovieList.Common;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> SearchMoviesByName(string movieName); 
    Task<Movie?> GetMovieById(int movieId);
    Task AddMovie(Movie movie);
    Task DeleteMovie(int movieId);
}