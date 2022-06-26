namespace TutorProject.Searcher.Front.Models;

public class TutorToSearch
{
    public string Subject { get; set; }
    public string WorkFormat { get; set; }
    public int MinPrice { get; set; }
    public int MaxPrice { get; set; }
    public int PupilClass { get; set; }
    public string TutorsOrder { get; set; }
    
    public bool Monday { get; set; }
    public bool Tuesday { get; set; }
    public bool Wednesday { get; set; }
    public bool Thursday { get; set; }
    public bool Friday { get; set; }
    public bool Saturday { get; set; }
    public bool Sunday { get; set; }

    public TutorToSearch()
    {
        Subject = "";
        WorkFormat = "";
        TutorsOrder = "";
        Monday = true;
        Tuesday = true;
        Wednesday = true;
        Thursday = true;
        Friday = true;
        Saturday = true;
        Sunday = true;
    }
}