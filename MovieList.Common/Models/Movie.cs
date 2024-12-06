
namespace MovieList.Common
{
    public class Movie
    {
        public int Id { get; set; } 
        public int TmdbId { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; } = "https://google.com";
        public DateTime? ReleaseDate { get; set; }
        public double? VoteAverage { get; set; }
        public int? VoteCount { get; set; }
        public List<int> Genres { get; set; }
        public string OriginalLanguage { get; set; }
        public string BackdropPath { get; set; }

        public List<MovieList> MovieLists { get; set; }
    }
}
