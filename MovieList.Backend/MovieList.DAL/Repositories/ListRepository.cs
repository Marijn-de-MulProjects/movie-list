using Microsoft.EntityFrameworkCore;
using MovieList.Common;

namespace MovieList.DAL.Repositories;

public class ListRepository : IListRepository
{
    private readonly DbContext _context;

    public ListRepository(DbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Common.MovieList>> GetUserListsFromUserId(int userId)
    {
        return await _context.MovieLists
            .Where(list => list.UserId == userId)  
            .Include(list => list.Movies)  
            .ToListAsync();
    }

    public async Task<List<Common.MovieList>> GetSharedListsFromUserId(int userId)
    {
        return await _context.MovieLists
            .Where(list => list.MovieListUsers.Any(m => m.UserId == userId)) 
            .Include(list => list.Movies)  
            .ToListAsync();
    }
}