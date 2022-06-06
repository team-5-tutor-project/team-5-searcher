using TutorProject.Account.Common.Models;

namespace TutorProject.Searcher.BLL.TutorSchedule.Services;

public interface ITutorScheduleService
{
    Task<Schedule> AddSchedule(Guid tutorId);
    Task<Schedule> AddFreeTime(Guid tutorId, DayOfWeek dayOfWeek, int lessonNumber);
    Task<Schedule> SetAllTimeFree(Guid tutorId);
    Task<List<Schedule>> GetAllSchedules();
    Task<Schedule> GetTutorSchedule(Guid tutorId);
    Task<Schedule> SetAllTimeTaken(Guid tutorId);
    Task<Schedule> SetTimeTaken(Guid tutorId, DayOfWeek dayOfWeek, int lessonNumber);
    Task<bool> DeleteSchedule(Guid tutorId);
}