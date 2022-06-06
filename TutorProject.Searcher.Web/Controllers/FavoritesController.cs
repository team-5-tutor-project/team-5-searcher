using System.Net;
using Microsoft.AspNetCore.Mvc;
using TutorProject.Account.Common;
using TutorProject.Searcher.BLL.Favorites.Services;

namespace TutorProject.Searcher.Web.Controllers;

[ApiController]
[Route("/favorites")]
public class FavoritesController : ControllerBase
{
    private readonly IFavoritesService _service;

    public FavoritesController(TutorContext context)
    {
        _service = new FavoritesService(context);
    }
    
    [HttpPost("{clientId}/addTutorToFavorites")]
    public async Task<IActionResult> AddTutorToFavorites(Guid clientId, [FromQuery] Guid tutorId)
    {
        if (await _service.AddTutorToFavorites(clientId, tutorId))
        {
            return Ok();
        }
        
        return StatusCode((int) HttpStatusCode.BadRequest);
    }
    
    [HttpDelete("{clientId}/deleteTutorFromFavorites")]
    public async Task<IActionResult> DeleteTutorFromFavorites(Guid clientId, [FromQuery] Guid tutorId)
    {
        if (await _service.DeleteTutorFromFavorites(clientId, tutorId))
        {
            return Ok();
        }
        
        return StatusCode((int) HttpStatusCode.BadRequest);
    }
}