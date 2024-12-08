using Microsoft.EntityFrameworkCore;
using MovieList.Common;

namespace MovieList.DAL.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly DbContext _context;

    public MovieRepository(DbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Movie>> SearchMoviesByName(string movieName)
    {
        return await _context.Movies
            .Where(m => EF.Functions.Like(m.Name, $"%{movieName}%")) 
            .ToListAsync();
    }

    public async Task<Movie?> GetMovieById(int movieId)
    {
        return await _context.Movies
            .FirstOrDefaultAsync(m => m.Id == movieId);
    }

    public async Task AddMovie(Movie movie)
    {
        var existingMovie = await _context.Movies.FindAsync(movie.Id);
        if (existingMovie == null)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteMovie(int movieId)
    {
        var movie = await _context.Movies.FindAsync(movieId);
        if (movie != null)
        {
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }
    }
}