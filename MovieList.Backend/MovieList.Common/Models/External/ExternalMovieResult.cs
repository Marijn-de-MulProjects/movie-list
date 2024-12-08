namespace MovieList.Common;

public class ExternalMovieResult
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Overview { get; set; }
    public string PosterPath { get; set; }
    public string ReleaseDate { get; set; }
    public double VoteAverage { get; set; }
    public int VoteCount { get; set; }
    public List<int> GenreIds { get; set; }
    public string OriginalLanguage { get; set; }
    public string BackdropPath { get; set; }
}