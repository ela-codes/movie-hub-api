using Microsoft.EntityFrameworkCore;
using MovieHubApi.Models;

public class ApplicationDbContext : DbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
  {
  }

  public DbSet<Movie> Movies { get; set; }
  public DbSet<MovieState> MovieStates { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    // configures how EF Core maps C# properties to database columns
    modelBuilder.Entity<Movie>(entity =>
    {
      entity.ToTable("movies", "public");
      entity.HasKey(e => e.Id);
      entity.Property(e => e.Id).HasColumnName("id");
      entity.Property(e => e.TmdbId).HasColumnName("tmdb_id");
      entity.Property(e => e.Title).HasColumnName("title");
      entity.Property(e => e.ReleaseDate).HasColumnName("release_date");
      entity.Property(e => e.PosterPath).HasColumnName("poster_path");
      entity.Property(e => e.CreatedAt).HasColumnName("created_at");
    });

    modelBuilder.Entity<MovieState>(entity =>
    {
      entity.ToTable("movie_state", "public");
      entity.HasKey(e => e.Id);
      entity.Property(e => e.Id).HasColumnName("id");
      entity.Property(e => e.MovieId).HasColumnName("movie_id");
      entity.Property(e => e.IsFavorite).HasColumnName("is_favorite");
      entity.Property(e => e.IsWatchLater).HasColumnName("is_watch_later");
      entity.Property(e => e.IsWatched).HasColumnName("is_watched");
      entity.Property(e => e.Review).HasColumnName("review");
      entity.Property(e => e.Rating).HasColumnName("rating");
      entity.Property(e => e.WatchedAt).HasColumnName("watched_at");
      entity.Property(e => e.CreatedAt).HasColumnName("created_at");
      entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
    });
  }
}