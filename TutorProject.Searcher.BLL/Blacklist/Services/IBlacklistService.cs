using TutorProject.Account.Common.Models;

namespace TutorProject.Searcher.BLL.Blacklist.Services;

public interface IBlacklistService
{
    Task<bool> AddTutorToBlacklist(Guid clientId, Guid tutorId);

    Task<bool> DeleteTutorFromBlacklist(Guid clientId, Guid tutorId);

    Task<List<Tutor>> GetTutorsFromBlacklist(Guid clientId);
}