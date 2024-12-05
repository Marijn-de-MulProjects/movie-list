using MovieList.Common;

namespace MovieList.SAL.Services;

public class ListService
{
    private readonly IListRepository _listRepository;

    public ListService(IListRepository listRepository)
    {
        _listRepository = listRepository;
    }
}