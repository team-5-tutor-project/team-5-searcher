using AutoMapper;
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
    private readonly IMapper _mapper;
 
    public TutorSearcherController(TutorContext context, IMapper mapper)
    {
        _service = new TutorSearcherService(context);
        _mapper = mapper;
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
    public async Task<IActionResult> Search(Guid clientId, [FromQuery] string? subject,
        [FromQuery] WorkFormat? workFormat, [FromQuery] int? minPrice, [FromQuery] int? maxPrice,
        [FromQuery] int? pupilClass, [FromQuery] List<bool>? schedule)
    {
        var tutors = await _service.Search(clientId, subject, workFormat, minPrice, maxPrice, pupilClass, schedule);

        if (tutors.Count != 0)
        {
            return Ok(tutors);
        }
        return NotFound();
    }
}