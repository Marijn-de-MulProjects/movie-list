namespace MovieList.Common;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }  

    public ICollection<MovieList> MovieLists { get; set; }
    public ICollection<MovieListUser> MovieListUsers { get; set; } = new List<MovieListUser>();
}