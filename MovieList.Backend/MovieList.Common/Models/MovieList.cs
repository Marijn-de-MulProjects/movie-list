namespace MovieList.Common;

public class MovieList
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int UserId { get; set; }  
    public ICollection<Movie> Movies { get; set; }  

    public ICollection<MovieListUser> MovieListUsers { get; set; }
}
