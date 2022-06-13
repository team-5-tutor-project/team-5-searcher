using TutorProject.Account.Common.Models;

namespace TutorProject.Searcher.BLL.Results;

public class ScheduleResult
{
    public Tutor Tutor { get; init; }

    public List<Day> FreeTimeSchedule { get; init; } = new List<Day>();
}

