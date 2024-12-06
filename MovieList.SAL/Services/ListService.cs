using MovieList.Common;

namespace MovieList.SAL.Services;

public class ListService
{
    private readonly IListRepository _listRepository;

    public ListService(IListRepository listRepository)
    {
        _listRepository = listRepository;
    }
    
    public async Task<List<Common.MovieList>> GetListsFromUserId(int userId)
    {
        var userLists = await _listRepository.GetUserListsFromUserId(userId);
        var sharedLists = await _listRepository.GetSharedListsFromUserId(userId);

        var allLists = userLists.Concat(sharedLists).Distinct().ToList();

        return allLists;
    }
}