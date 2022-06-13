using TutorProject.Account.Common.Models;

namespace TutorProject.Searcher.BLL.Results;

public class ScheduleResult
{
    public TutorResult Tutor { get; init; }

    public List<DayResult> FreeTimeSchedule { get; init; } = new List<DayResult>();
}

