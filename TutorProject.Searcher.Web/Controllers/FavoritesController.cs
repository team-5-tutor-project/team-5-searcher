using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TutorProject.Account.Common;
using TutorProject.Searcher.BLL.Favorites.Services;
using TutorProject.Searcher.BLL.Results;

namespace TutorProject.Searcher.Web.Controllers;

[ApiController]
[Route("/favorites")]
public class FavoritesController : ControllerBase
{
    private readonly IFavoritesService _service;
    private readonly IMapper _mapper;

    public FavoritesController(TutorContext context, IMapper mapper)
    {
        _service = new FavoritesService(context);
        _mapper = mapper;
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

    [HttpGet("{clientId}/getTutorsFromFavorites")]
    public async Task<IActionResult> GetTutorsFromFavorites(Guid clientId)
    {
        var tutors = await _service.GetTutorsFromFavorites(clientId);
        if (tutors.Count != 0)
        {
            return Ok(_mapper.Map<List<TutorResult>>(tutors));
        }

        return NotFound();
    }
}