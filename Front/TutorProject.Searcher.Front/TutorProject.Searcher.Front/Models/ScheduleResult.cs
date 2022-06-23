namespace TutorProject.Searcher.Front.Models;

public class ScheduleResult
{
    public TutorResult Tutor { get; set; }

    public List<DayResult> FreeTimeSchedule { get; init; } = new List<DayResult>(7);

    public ScheduleResult()
    {
        for (int i = 0; i < 7; i++)
        {
            FreeTimeSchedule.Add(new DayResult());
        }
    }
}