namespace MovieHubApi.Models;

public class Movie
{
    private DateTime _releaseDate;
    public Guid Id { get; set; }
    public int TmdbId { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime? ReleaseDate
    {
        get => _releaseDate;
        set
        {
            if (value.HasValue)
            {
                // convert to DateTime.UtcNow for postgreSQL compatibility
                _releaseDate = value.Value.ToUniversalTime();
            }
        }
    }
    public string? PosterPath { get; set; }
    public DateTime CreatedAt { get; private set; }

    public Movie()
    {
        CreatedAt = DateTime.UtcNow;
    }

    
}