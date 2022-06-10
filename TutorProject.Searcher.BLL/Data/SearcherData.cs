using TutorProject.Account.Common.Models;
namespace TutorProject.Searcher.BLL.Data;

public class SearcherData
{
    public Subject? Subject { get; set; }
    public WorkFormat? WorkFormat { get; set; }
    public int? MinPrice { get; set; }
    public int? MaxPrice { get; set; }
    public int? PupilClass { get; set; }
    public List<bool>? Schedule { get; set; } 
    public TutorsOrder? TutorsOrder { get; set; }
}