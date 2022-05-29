using Microsoft.AspNetCore.Mvc;
using TutorProject.Account.Common;
using TutorProject.Account.Common.Models;
using TutorProject.Searcher.Web.Services;

namespace TutorProject.Searcher.Web.Controllers;

[ApiController]
public class TutorSearcherController : ControllerBase
{
    private readonly TutorSearcherService _service;

    public TutorSearcherController(TutorContext context)
    {
        _service = new TutorSearcherService(context);
    }
    
    [HttpGet("allTutors")]
    public List<Tutor> GetAll()
    {
        var tutors = _service.GetAll();
        return tutors;
    }
    
    [HttpGet("search")]
    public List<TutorToSubject> Search( string? subject, WorkFormat? workFormat, int? minPrice, int? maxPrice, int? pupilClass)
    {
        var tutors = _service.Search(subject, workFormat, minPrice, maxPrice, pupilClass);
        return tutors;
    }
}