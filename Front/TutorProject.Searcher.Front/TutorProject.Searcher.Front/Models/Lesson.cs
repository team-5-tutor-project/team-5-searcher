namespace TutorProject.Searcher.Front.Models;

public class Lesson
{
    public Guid TutorId { get; set; }
    public int DayOfWeek { get; set; }
    public int LessonTime { get; set; }
}