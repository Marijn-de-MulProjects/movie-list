namespace MovieList.Common;

public class ExternalTvApiResponse
{
    public int Page { get; set; }
    public List<TvResult> Results { get; set; }
    public int TotalPages { get; set; }
    public int TotalResults { get; set; }
}
