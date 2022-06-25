namespace TutorProject.Searcher.Front.Models;

public class ClientToTutor
{
    public Guid Id { get; init; }
        
    public Guid Client { get; init; }
        
    public Guid Tutor { get; init; }
}