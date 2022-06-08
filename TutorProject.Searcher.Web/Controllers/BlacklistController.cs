using System.Net;
using Microsoft.AspNetCore.Mvc;
using TutorProject.Account.Common;
using TutorProject.Searcher.BLL.Blacklist.Services;

namespace TutorProject.Searcher.Web.Controllers;

[ApiController]
[Route("/blacklist")]
public class BlacklistController : ControllerBase
{
    private readonly IBlacklistService _service;

    public BlacklistController(TutorContext context)
    {
        _service = new BlacklistService(context);
    }
    
    [HttpPost("{clientId}/addTutorToBlacklist")]
    public async Task<IActionResult> AddTutorToBlacklist(Guid clientId, [FromQuery] Guid tutorId)
    {
        if (await _service.AddTutorToBlacklist(clientId, tutorId))
        {
            return Ok();
        }
        
        return StatusCode((int) HttpStatusCode.BadRequest);
    }
    
    [HttpDelete("{clientId}/deleteTutorFromBlacklist")]
    public async Task<IActionResult> DeleteTutorFromBlacklist(Guid clientId, [FromQuery] Guid tutorId)
    {
        if (await _service.DeleteTutorFromBlacklist(clientId, tutorId))
        {
            return Ok();
        }
        
        return StatusCode((int) HttpStatusCode.BadRequest);
    }
    
    [HttpGet("{clientId}/getTutorsFromBlacklist")]
    public async Task<IActionResult> GetTutorsFromBlacklist(Guid clientId)
    {
        var tutors = await _service.GetTutorsFromBlacklist(clientId);
        if (tutors.Count != 0)
        {
            return Ok(tutors);
        }

        return NotFound();
    }
}