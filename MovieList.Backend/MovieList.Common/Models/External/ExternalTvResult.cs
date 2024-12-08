namespace MovieList.Common;

public class TvResult
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Overview { get; set; }
    public string PosterPath { get; set; }
    public string BackdropPath { get; set; }
    public string OriginalLanguage { get; set; }
    public string FirstAirDate { get; set; }
    public double VoteAverage { get; set; }
    public int VoteCount { get; set; }
    public List<int> GenreIds { get; set; }
}