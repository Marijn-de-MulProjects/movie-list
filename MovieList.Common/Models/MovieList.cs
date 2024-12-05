namespace MovieList.Common;

public class MovieList
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }  

    public ICollection<Movie> Movies { get; set; }
}