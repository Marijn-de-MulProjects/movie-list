using Microsoft.EntityFrameworkCore;
using MovieList.Common;

namespace MovieList.DAL
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Common.MovieList> MovieLists { get; set; }

        public DbContext(DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.PictureUrl).HasMaxLength(500);
                entity.Property(e => e.TmdbId).IsRequired();
                entity.Property(e => e.ReleaseDate).HasColumnType("date");
                entity.Property(e => e.VoteAverage).IsRequired();
                entity.Property(e => e.VoteCount).IsRequired();
                entity.Property(e => e.OriginalLanguage).HasMaxLength(10);
                entity.Property(e => e.BackdropPath).HasMaxLength(500);

                entity.Property(e => e.Genres)
                    .HasConversion(
                        v => string.Join(",", v),  
                        v => v.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()  
                    );
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(250);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(255);
            });

            modelBuilder.Entity<Common.MovieList>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);

                entity.HasOne(ml => ml.User)
                      .WithMany(u => u.MovieLists)
                      .HasForeignKey(ml => ml.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.MovieLists)
                .WithMany(ml => ml.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieListMovies",
                    j => j.HasOne<Common.MovieList>().WithMany().HasForeignKey("MovieListId"),
                    j => j.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                    j =>
                    {
                        j.HasKey("MovieId", "MovieListId");
                    });
        }
    }
}
