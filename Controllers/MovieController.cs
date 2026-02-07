using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieHubApi.Models;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
  private readonly ApplicationDbContext _context;

  public MoviesController(ApplicationDbContext context)
  {
    _context = context;
  }

  [HttpGet]
  public async Task<ActionResult<List<Movie>>> GetMovies()
  {
    var movies = await _context.Movies.ToListAsync();
    if (movies == null)
    {
      return NotFound();
    }
    return movies;
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Movie>> GetMovie(Guid id)
  {
    var movie = await _context.Movies.FindAsync(id);
    if (movie == null)
    {
      return NotFound();
    }
    return movie;
  }


  [HttpPost]
  public async Task<ActionResult<Movie>> CreateMovie(Movie movie)
  {
    _context.Movies.Add(movie);
    await _context.SaveChangesAsync();
    return CreatedAtAction(nameof(GetMovie), new
    {
      id = movie.Id
    }, movie);
  }
}