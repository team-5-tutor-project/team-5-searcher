namespace TutorProject.Searcher.BLL.Results;

public class DayResult
{
    public DayResult()
    {
        for (int j = 0; j < 12; j++)
        {
            DaySchedule.Add(false);
        }
    }

    public List<bool> DaySchedule { get; init; } = new List<bool>();
}