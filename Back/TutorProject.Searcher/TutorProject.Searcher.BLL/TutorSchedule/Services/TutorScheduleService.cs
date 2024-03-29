﻿using TutorProject.Account.Common;
using TutorProject.Account.Common.Models;
using TutorProject.Searcher.BLL.Data;
using TutorProject.Searcher.BLL.TutorSchedule.Repositories;

namespace TutorProject.Searcher.BLL.TutorSchedule.Services;

public class TutorScheduleService : ITutorScheduleService
{
    private readonly TutorScheduleRepository _repository;

    public TutorScheduleService(TutorContext context)
    {
        _repository = new TutorScheduleRepository(context);
    }

    public async Task<Schedule?> AddSchedule(Guid tutorId)
    {
        return await _repository.AddSchedule(tutorId);
    }

    public async Task<Schedule?> AddFreeTime(Guid tutorId, ScheduleData scheduleData)
    {
        return await _repository.AddFreeTime(
            tutorId, 
            scheduleData.DayOfWeek, 
            scheduleData.LessonNumber);
    }

    public async Task<Schedule?> SetAllTimeFree(Guid tutorId)
    {
        return await _repository.SetAllTimeFree(tutorId);
    }

    public async Task<Schedule?> GetTutorSchedule(Guid tutorId)
    {
        return await _repository.GetTutorSchedule(tutorId);
    }

    public async Task<Schedule?> SetAllTimeTaken(Guid tutorId)
    {
        return await _repository.SetAllTimeTaken(tutorId);
    }

    public async Task<bool> DeleteSchedule(Guid tutorId)
    {
        return await _repository.DeleteSchedule(tutorId);
    }
    
    public async Task<Schedule?> SetTimeTaken(Guid tutorId, ScheduleData scheduleData)
    {
        return await _repository.SetTimeTaken(
            tutorId, 
            scheduleData.DayOfWeek, 
            scheduleData.LessonNumber);
    }
}