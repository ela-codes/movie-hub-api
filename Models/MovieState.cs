namespace MovieHubApi.Models;

public class MovieState
{
    public Guid Id { get; set; }
    public Guid MovieId { get; set; }
    public bool IsFavorite { get; set; }
    public bool IsWatchLater { get; set; }
    public bool IsWatched { get; set; }
    public string? Review { get; set; }
    public short? Rating { get; set; }
    public DateTime? WatchedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}