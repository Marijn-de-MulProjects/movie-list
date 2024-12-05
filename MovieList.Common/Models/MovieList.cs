namespace MovieList.Common;

public class MovieList
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CreatedByUserId { get; set; }
    public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    public ICollection<User> SharedWithUsers { get; set; } = new List<User>();
}