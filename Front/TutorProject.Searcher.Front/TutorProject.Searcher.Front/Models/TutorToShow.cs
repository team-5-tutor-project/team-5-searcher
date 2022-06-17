namespace TutorProject.Searcher.Front.Models;

public class TutorToShow
{
    public TutorResult Tutor { get; set; }
    public string Subjects { get; set; }

    public TutorToShow(TutorResult tutor, List<string> subjects)
    {
        Tutor = tutor;
        Subjects = "";
        foreach (var subject in subjects)
        {
            Subjects += subject + " ";
        }

        //Subjects.TrimEnd(',');
    }
}