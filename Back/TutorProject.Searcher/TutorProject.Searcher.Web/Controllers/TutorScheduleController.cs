using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TutorProject.Account.Common;
using TutorProject.Searcher.BLL.Data;
using TutorProject.Searcher.BLL.Results;
using TutorProject.Searcher.BLL.TutorSchedule.Services;
using TutorProject.Searcher.Web.Dto;

namespace TutorProject.Searcher.Web.Controllers;

[ApiController]
[Route("/schedule")]
public class TutorScheduleController : ControllerBase
{
    private readonly ITutorScheduleService _service;
    private readonly IMapper _mapper;

    public TutorScheduleController(TutorContext context, IMapper mapper)
    {
        _service = new TutorScheduleService(context);
        _mapper = mapper;
    }

    [HttpPost("addSchedule")]
    public async Task<IActionResult> AddSchedule([FromQuery] Guid tutorId)
    {
        var result = await _service.AddSchedule(tutorId);
        
        if (result == null)
        {
            NotFound();
        }
        
        return Ok(_mapper.Map<List<ScheduleResult>>(result));
    }
    
    [HttpPut("{tutorId}/addFreeTime")]
    public async Task<IActionResult> AddFreeTime(Guid tutorId, 
        [FromQuery] ScheduleDto scheduleDto)
    {
        var scheduleData = _mapper.Map<ScheduleData>(scheduleDto);
        var result = await _service.AddFreeTime(tutorId, scheduleData);
        
        if (result == null)
        {
            NotFound();
        }
        
        return Ok(_mapper.Map<ScheduleResult>(result));
    }
    
    [HttpDelete("{tutorId}/setAllTimeFree")]
    public async Task<IActionResult> AddFreeTime(Guid tutorId)
    {
        var result = await _service.SetAllTimeFree(tutorId);

        if (result == null)
            return NotFound();

        return Ok(_mapper.Map<ScheduleResult>(result));
    }
    
    [HttpGet("{tutorId}/getSchedule")]
    public async Task<IActionResult> GetTutorSchedule(Guid tutorId)
    {
        var result = await _service.GetTutorSchedule(tutorId);

        if (result == null)
        {
            NotFound();
        }
        
        return Ok(_mapper.Map<ScheduleResult>(result));
    }

    [HttpDelete("{tutorId}/setAllTimeTaken")]
    public async Task<IActionResult> SetAllTimeTaken(Guid tutorId)
    {
        var result = await _service.SetAllTimeTaken(tutorId);

        if (result == null)
        {
            NotFound();
        }
        
        return Ok(_mapper.Map<ScheduleResult>(result));
    }
    
    [HttpPut("{tutorId}/setTimeTaken")]
    public async Task<IActionResult> SetTimeTaken(
        Guid tutorId, 
        [FromQuery] ScheduleDto scheduleDto)
    {
        var scheduleData = _mapper.Map<ScheduleData>(scheduleDto);
        var result = await _service.SetTimeTaken(tutorId, scheduleData);

        if (result == null)
        {
            NotFound();
        }
        
        return Ok(_mapper.Map<ScheduleResult>(result));
    }
    
    [HttpDelete("{tutorId}/deleteSchedule")]
    public async Task<IActionResult> DeleteSchedule(Guid tutorId)
    {
        if (await _service.DeleteSchedule(tutorId))
        {
            return Ok();
        }
        
        return NotFound();
    }
}