using Microsoft.AspNetCore.Mvc;
using MovieList.SAL.Services;

namespace MovieList.API.Controllers;

[ApiController]
[Route("api/movies")]
public class MovieController : ControllerBase
{
    #region Search Movies

    [HttpGet("search")]
    public IActionResult SearchMovie([FromQuery] string movieName)
    {
        return Ok(); 
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