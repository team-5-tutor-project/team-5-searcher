using TutorProject.Account.Common;
using TutorProject.Account.Common.Models;
using TutorProject.Searcher.BLL.TutorSchedule.Repositories;

namespace TutorProject.Searcher.BLL.TutorSchedule.Services;

public class TutorScheduleService : ITutorScheduleService
{
    private readonly TutorScheduleRepository _repository;

    public TutorScheduleService(TutorContext context)
    {
        _repository = new TutorScheduleRepository(context);
    }

    public async Task<Schedule> AddSchedule(Guid tutorId)
    {
        return await _repository.AddSchedule(tutorId);
    }

    public async Task<Schedule> AddFreeTime(Guid tutorId, DayOfWeek dayOfWeek, int lessonNumber)
    {
        return await _repository.AddFreeTime(tutorId, dayOfWeek, lessonNumber);
    }

    public async Task<Schedule> SetAllTimeFree(Guid tutorId)
    {
        return await _repository.SetAllTimeFree(tutorId);
    }
    
    public async Task<List<Schedule>> GetAllSchedules()
    {
        return await _repository.GetAllSchedules();
    }

    public async Task<Schedule> GetTutorSchedule(Guid tutorId)
    {
        return await _repository.GetTutorSchedule(tutorId);
    }
}