using TutorProject.Account.Common.Models;
using TutorProject.Searcher.BLL.Data;

namespace TutorProject.Searcher.BLL.TutorSchedule.Services;

public interface ITutorScheduleService
{
    Task<Schedule?> AddSchedule(Guid tutorId);
    Task<Schedule?> AddFreeTime(Guid tutorId, ScheduleData scheduleData);
    Task<Schedule?> SetAllTimeFree(Guid tutorId);
    Task<List<Schedule>?> GetAllSchedules();
    Task<Schedule?> GetTutorSchedule(Guid tutorId);
    Task<Schedule?> SetAllTimeTaken(Guid tutorId);
    Task<Schedule?> SetTimeTaken(Guid tutorId, ScheduleData scheduleData);
    Task<bool> DeleteSchedule(Guid tutorId);
}