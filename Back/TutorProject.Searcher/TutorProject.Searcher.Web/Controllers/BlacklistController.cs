using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TutorProject.Account.Common;
using TutorProject.Searcher.BLL.Blacklist.Services;
using TutorProject.Searcher.BLL.Results;

namespace TutorProject.Searcher.Web.Controllers;

[ApiController]
[Route("/blacklist")]
public class BlacklistController : ControllerBase
{
    private readonly IBlacklistService _service;
    private readonly IMapper _mapper;

    public BlacklistController(TutorContext context, IMapper mapper)
    {
        _service = new BlacklistService(context);
        _mapper = mapper;
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

    [HttpGet("{clientId}/checkTutorInBlacklist")]
    public async Task<bool> CheckTutorInBlacklist(Guid clientId, [FromQuery] Guid tutorId)
    {
        return await _service.CheckTutorInBlacklist(clientId, tutorId);
    }
    
    [HttpGet("{clientId}/getTutorsFromBlacklist")]
    public async Task<IActionResult> GetTutorsFromBlacklist(Guid clientId)
    {
        var tutors = await _service.GetTutorsFromBlacklist(clientId);
        if (tutors.Count != 0)
        {
            return Ok(_mapper.Map<List<TutorResult>>(tutors));
        }

        return NotFound();
    }
}