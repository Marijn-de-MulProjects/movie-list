using Microsoft.AspNetCore.Mvc;
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
    public IActionResult GetMovieById(int movieId)
    {
        return Ok(); 
    }

    #endregion

    #region Manage Movies

    [HttpPost]
    public IActionResult AddMovie()
    {
        return StatusCode(201); 
    }

    [HttpDelete("{movieId}")]
    public IActionResult DeleteMovie(int movieId)
    {
        return NoContent(); 
    }

    #endregion
}