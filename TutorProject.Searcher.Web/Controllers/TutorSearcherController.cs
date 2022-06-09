using Microsoft.AspNetCore.Mvc;
using TutorProject.Account.Common;
using TutorProject.Account.Common.Models;
using TutorProject.Searcher.BLL.Searcher.Services;

namespace TutorProject.Searcher.Web.Controllers;

[ApiController]
[Route("/searcher")]
public class TutorSearcherController : ControllerBase
{
    private readonly ITutorSearcherService _service;

    public TutorSearcherController(TutorContext context)
    {
        _service = new TutorSearcherService(context);
    }
    
    [HttpGet("{clientId}/getAllTutors")]
    public async Task<IActionResult> GetAll(Guid clientId)
    {
        var tutors = await _service.GetAll(clientId);
        
        if (tutors.Count != 0)
        {
            return Ok(tutors);
        }
        return NotFound();
    }
    
    [HttpGet("{clientId}/search")]
    public async Task<IActionResult> Search(Guid clientId, string? subject, WorkFormat? workFormat, int? minPrice, int? maxPrice, int? pupilClass)
    {
        var tutors = await _service.Search(clientId, subject, workFormat, minPrice, maxPrice, pupilClass);

        if (tutors.Count != 0)
        {
            return Ok(tutors);
        }
        return NotFound();
    }
}