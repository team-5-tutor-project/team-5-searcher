using TutorProject.Account.Common;
using TutorProject.Account.Common.Models;
using TutorProject.Searcher.BLL.Blacklist.Repositories;

namespace TutorProject.Searcher.BLL.Blacklist.Services;

public class BlacklistService : IBlacklistService
{
    private readonly BlacklistRepository _repository;

    public BlacklistService(TutorContext context)
    {
        _repository = new BlacklistRepository(context);
    }
    
    public async Task<bool> AddTutorToBlacklist(Guid clientId, Guid tutorId)
    {
        return await _repository.AddTutorToBlacklist(clientId, tutorId);
    }

    public async Task<bool> DeleteTutorFromBlacklist(Guid clientId, Guid tutorId)
    {
        return await _repository.DeleteTutorFromBlacklist(clientId, tutorId);
    }

    public async Task<bool> CheckTutorInBlacklist(Guid clientId, Guid tutorId)
    {
        return await _repository.CheckTutorInBlacklist(clientId, tutorId);
    }
    
    public async Task<List<Tutor>> GetTutorsFromBlacklist(Guid clientId)
    {
        var clientToTutor = await _repository.GetTutorsFromBlacklist(clientId);
        var tutors = new List<Tutor>();
        foreach (var clientTutor in clientToTutor)
        {
            tutors.Add(clientTutor.Tutor);
        }

        return tutors;
    }
}