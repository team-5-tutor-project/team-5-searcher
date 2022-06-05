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
    public async Task<Schedule?> AddSchedule([FromQuery] Guid tutorId)
    {
        return await _service.AddSchedule(tutorId);
    }
    
    [HttpPut("{tutorId}/addFreeTime")]
    public async Task<Schedule?> AddFreeTime(Guid tutorId, 
        [FromQuery] DayOfWeek dayOfWeek,
        [FromQuery] int lessonNumber)
    {
        return await _service.AddFreeTime(tutorId, dayOfWeek, lessonNumber);
    }
    
    [HttpPut("{tutorId}/setAllTimeFree")]
    public async Task<Schedule?> AddFreeTime(Guid tutorId)
    {
        return await _service.SetAllTimeFree(tutorId);
    }
}