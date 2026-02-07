using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieHubApi.Models;

[ApiController]
[Route("api/[controller]")]
public class MovieStateController : ControllerBase
{
  private readonly ApplicationDbContext _context;

  public MovieStateController(ApplicationDbContext context)
  {
    _context = context;
  }

  [HttpGet]
  public async Task<ActionResult<List<MovieState>>> GetMovieStates()
  {
    var movieStates = await _context.MovieStates.ToListAsync();
    if (movieStates == null)
    {
      return NotFound();
    }
    return movieStates;
  }

  [HttpGet]
  [Route("favorites")]
  public async Task<ActionResult<List<MovieState>>> GetFavorites()
  {
    var favorites = await _context.MovieStates.Where(ms => ms.IsFavorite).ToListAsync();
    if (favorites == null)
    {
      return NotFound();
    }
    return favorites;
  }

  [HttpGet]
  [Route("watchlater")]
  public async Task<ActionResult<List<MovieState>>> GetWatchLater()
  {
    var watchLater = await _context.MovieStates.Where(ms => ms.IsWatchLater).ToListAsync();
    if (watchLater == null)
    {
      return NotFound();
    }
    return watchLater;
  }

  [HttpGet]
  [Route("watched")]
  public async Task<ActionResult<List<MovieState>>> GetWatched()
  {
    var watched = await _context.MovieStates.Where(ms => ms.IsWatched).ToListAsync();
    if (watched == null)
    {
      return NotFound();
    }
    return watched;
  }

  [HttpGet]
  [Route("reviews")]
  public async Task<ActionResult<List<MovieState>>> GetReviews()
  {
    var reviews = await _context.MovieStates.Where(ms => ms.Review != null).ToListAsync();
    if (reviews == null)
    {
      return NotFound();
    }
    return reviews;
  }
}