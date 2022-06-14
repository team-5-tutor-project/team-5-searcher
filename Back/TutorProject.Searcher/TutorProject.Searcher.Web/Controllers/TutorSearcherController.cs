using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TutorProject.Account.Common;
using TutorProject.Searcher.BLL.Data;
using TutorProject.Searcher.BLL.Results;
using TutorProject.Searcher.BLL.Searcher.Services;
using TutorProject.Searcher.Web.Dto;

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
            return Ok(_mapper.Map<List<TutorResult>>(tutors));
        }
        return NotFound();
    }
    
    [HttpGet("{tutorId}/getAllSubjects")]
    public async Task<IActionResult> GetSubjectsForTutor(Guid tutorId)
    {
        var subjects = await _service.GetSubjectsForTutor(tutorId);
        
        if (subjects.Count != 0)
        {
            return Ok(subjects);
        }
        return NotFound();
    }
    
    [HttpGet("{clientId}/search")]
    public async Task<IActionResult> Search(Guid clientId, [FromQuery] SearcherDto searcherDto)
    {
        var searcherData = _mapper.Map<SearcherData>(searcherDto);
        var tutors = await _service.Search(clientId, searcherData);

        if (tutors.Count != 0)
        {
            return Ok(_mapper.Map<List<TutorResult>>(tutors));
        }
        
        return NotFound();
    }
}