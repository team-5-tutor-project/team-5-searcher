namespace TutorProject.Searcher.Front.Models;

public class TutorResult
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    
    public WorkFormat WorkFormat { get; set; }
        
    public string Description { get; set; }
        
    public int PricePerHour { get; set; }
        
    public int PupilMinClass { get; set; }
        
    public int PupilMaxClass { get; set; }
}