using Microsoft.AspNetCore.Mvc;

namespace MovieList.API.Controllers;

[ApiController]
[Route("api/lists")]
public class UserController : ControllerBase
{
    #region Authentication

    [HttpPost("register")]
    public IActionResult Register()
    {
        return StatusCode(201); 
    }

    [HttpPost("login")]
    public IActionResult Login()
    {
        return Ok(); 
    }

    #endregion

    #region User Information

    [HttpGet("{userId}")]
    public IActionResult GetUserById(int userId)
    {
        return Ok(); 
    }

    [HttpGet("me")]
    public IActionResult GetCurrentUser()
    {
        return Ok(); 
    }

    #endregion
}