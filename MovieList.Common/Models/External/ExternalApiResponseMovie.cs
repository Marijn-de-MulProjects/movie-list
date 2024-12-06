namespace MovieList.Common;

public class ExternalApiResponseMovie
{
    public int Page { get; set; }
    public int TotalPages { get; set; }

    public int TotalResults { get; set; }
    public List<ExternalMovieResult> Results { get; set; }
}