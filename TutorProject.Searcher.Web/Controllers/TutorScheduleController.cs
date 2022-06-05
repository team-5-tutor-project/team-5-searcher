using Microsoft.AspNetCore.Mvc;
using TutorProject.Account.Common;
using TutorProject.Account.Common.Models;
using TutorProject.Searcher.BLL.TutorSchedule.Services;

namespace TutorProject.Searcher.Web.Controllers;

[ApiController]
[Route("/schedule")]
public class TutorScheduleController : ControllerBase
{
    private readonly ITutorScheduleService _service;

    public TutorScheduleController(TutorContext context)
    {
        _service = new TutorScheduleService(context);
    }

    [HttpPost("addSchedule")]
    public async Task<Schedule> AddSchedule([FromQuery] Guid tutorId)
    {
        var result = await _service.AddSchedule(tutorId);
        
        if (result == null)
        {
            throw new Exception(BadRequest().ToString());
        }
        
        return result;
    }
    
    [HttpPut("{tutorId}/addFreeTime")]
    public async Task<Schedule> AddFreeTime(Guid tutorId, 
        [FromQuery] DayOfWeek dayOfWeek,
        [FromQuery] int lessonNumber)
    {
        var result = await _service.AddFreeTime(tutorId, dayOfWeek, lessonNumber);
        
        if (result == null)
        {
            throw new Exception(BadRequest().ToString());
        }
        
        return result;
    }
    
    [HttpPut("{tutorId}/setAllTimeFree")]
    public async Task<Schedule> AddFreeTime(Guid tutorId)
    {
        var result = await _service.SetAllTimeFree(tutorId);
        
        if (result == null)
        {
            throw new Exception(BadRequest().ToString());
        }
        
        return result;
    }
}