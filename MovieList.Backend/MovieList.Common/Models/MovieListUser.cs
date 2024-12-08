namespace MovieList.Common;

public class MovieListUser
{
    public int UserId { get; set; }
    public User User { get; set; }

    public int MovieListId { get; set; }
    public MovieList MovieList { get; set; }
}