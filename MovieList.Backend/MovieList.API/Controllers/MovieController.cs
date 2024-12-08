using Microsoft.AspNetCore.Mvc;
using MovieList.Common;
using MovieList.SAL.Services;

namespace MovieList.API.Controllers;

[ApiController]
[Route("api/movies")]
public class MovieController : ControllerBase
{
    private readonly MovieService _movieService;
    public MovieController(MovieService movieService)
    {
        _movieService = movieService;
    }
    
    #region Search Movies

    [HttpGet("search")]
    public async Task<IActionResult> SearchMovie([FromQuery] string movieName)
    {
        var result = await _movieService.SearchMovie(movieName);
        return Ok(result); 
    }

    [HttpGet("{movieId}")]
    public async Task<IActionResult> GetMovieById(int movieId)
    {
        var movie = await _movieService.GetMovieById(movieId);
        
        if (movie == null)
        {
            return NotFound($"Movie with ID {movieId} not found.");
        }

        return Ok(movie);
    }

    #endregion

    #region Manage Movies

    [HttpPost]
    [HttpPost]
    public async Task<IActionResult> AddMovie([FromBody] Movie movie)
    {
        if (movie == null)
        {
            return BadRequest("Movie data is required.");
        }

        var addedMovie = await _movieService.AddMovie(movie);

        if (addedMovie == null)
        {
            return StatusCode(500, "There was an error adding the movie.");
        }

        return Ok(); 
    }

    [HttpDelete("{movieId}")]
    public IActionResult DeleteMovie(int movieId)
    {
        var movie = _movieService.GetMovieById(movieId);
        
        if (movie == null)
        {
            return NotFound($"Movie with ID {movieId} not found.");
        }
        
        _movieService.DeleteMovie(movieId);
        
        return NoContent(); 
    }

    #endregion
}