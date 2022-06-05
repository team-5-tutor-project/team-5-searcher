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
    
    [HttpGet("getAllTutors")]
    public async Task<List<Tutor>> GetAll()
    {
        return await _service.GetAll();
    }
    
    [HttpGet("search")]
    public async Task<List<TutorToSubject>> Search(string? subject, WorkFormat? workFormat, int? minPrice, int? maxPrice, int? pupilClass)
    {
        var tutors = await _service.Search( subject, workFormat, minPrice, maxPrice, pupilClass);
        return tutors;
    }
}