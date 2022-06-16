namespace TutorProject.Searcher.Front.Models;

public class TutorToSearch
{
    public Guid TutorId;
    public string Subject { get; set; }
    //public WorkFormat WorkFormat { get; set; }
    public string WorkFormat { get; set; }
    public int MinPrice { get; set; }
    public int MaxPrice { get; set; }
    public int PupilClass { get; set; }
    //public TutorsOrder TutorsOrder { get; set; }
    public string TutorsOrder { get; set; }
    public List<bool> Schedule { get; set; } 
}