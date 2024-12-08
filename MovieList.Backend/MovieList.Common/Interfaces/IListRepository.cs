namespace MovieList.Common;

public interface IListRepository
{
    Task<List<Common.MovieList>> GetUserListsFromUserId(int userId);
    Task<List<Common.MovieList>> GetSharedListsFromUserId(int userId); 
}