using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MovieList.SAL.Services;

namespace MovieList.API.Controllers;

[ApiController]
[Route("api/lists")]
public class ListController : ControllerBase
{
    #region Manage List
    
    [HttpGet]
    public IActionResult GetAllLists()
    {
        return Ok(); 
    }

    [HttpGet("{listId}")]
    public IActionResult GetListById(int listId)
    {
        return Ok(); 
    }

    [HttpPost]
    public IActionResult CreateList()
    {
        return StatusCode(201); 
    }

    [HttpPut("{listId}")]
    public IActionResult UpdateList(int listId)
    {
        return NoContent(); 
    }

    [HttpDelete("{listId}")]
    public IActionResult DeleteList(int listId)
    {
        return NoContent(); 
    }
    
    #endregion
    
    #region Manage Movies in List
    
    [HttpPost("{listId}/movies")]
    public IActionResult AddMovieToList(int listId)
    {
        return StatusCode(201); 
    }

    [HttpDelete("{listId}/movies/{movieId}")]
    public IActionResult RemoveMovieFromList(int listId, int movieId)
    {
        return NoContent(); 
    }
    
    #endregion

    #region Manage Users in List

    [HttpPost("{listId}/share")]
    public IActionResult ShareList(int listId)
    {
        return Ok(); 
    }

    [HttpGet("{listId}/share")]
    public IActionResult GetSharedUsers(int listId)
    {
        return Ok(); 
    }

    [HttpDelete("{listId}/share/{userId}")]
    public IActionResult RevokeSharedAccess(int listId, int userId)
    {
        return NoContent(); 
    }

    #endregion
}