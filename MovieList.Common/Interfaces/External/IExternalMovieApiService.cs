namespace MovieList.Common;

public interface IExternalMovieApiService
{
    Task<IEnumerable<Movie>> SearchMovieByName(string movieName);
}