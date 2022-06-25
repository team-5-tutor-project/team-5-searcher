namespace TutorProject.Searcher.Front.Models;

public class TutorToSearch
{
    public string Subject { get; set; }
    public string WorkFormat { get; set; }
    public int MinPrice { get; set; }
    public int MaxPrice { get; set; }
    public int PupilClass { get; set; }
    public string TutorsOrder { get; set; }
    //public List<bool> Schedule { get; set; }

    public TutorToSearch()
    {
        Subject = "";
        WorkFormat = "";
        TutorsOrder = "";
    }
}