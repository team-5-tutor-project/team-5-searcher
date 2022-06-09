using TutorProject.Account.Common;
using TutorProject.Account.Common.Models;
using TutorProject.Searcher.BLL.Blacklist.Repositories;
using TutorProject.Searcher.BLL.Searcher.Repositories;

namespace TutorProject.Searcher.BLL.Searcher.Services;

public class TutorSearcherService : ITutorSearcherService
{
    private readonly TutorSearcherRepository _repository;
    private readonly BlacklistRepository _blacklistRepository;

    public TutorSearcherService(TutorContext context)
    {
        _repository = new TutorSearcherRepository(context);
        _blacklistRepository = new BlacklistRepository(context);
    }

    public async Task<List<Tutor>> GetAll(Guid clientId)
    {
        var tutors = await _repository.GetAll();
        var black = await  _blacklistRepository.GetTutorsFromBlacklist(clientId);
        foreach (var clientTutor in black)
        {
            tutors.Remove(clientTutor.Tutor);
        }
        return tutors;
    }

    private async Task<bool> CheckInBlacklist(Guid clientId, Guid tutorId)
    {
        var tutorBlacklist = await _repository.CheckInBlacklist(clientId, tutorId);
        if (tutorBlacklist == null)
        {
            return false;
        }
        return true;
    }
    
    public async Task<List<Tutor>> Search(Guid clientId, string? subject, WorkFormat? workFormat, int? minPrice,
        int? maxPrice, int? pupilClass)
    {
        var tutorsToSubject = await _repository.Search( subject, workFormat, minPrice, maxPrice, pupilClass);
        var tutors = new List<Tutor>();
        foreach (var tutorToSubj in tutorsToSubject)
        {
            if (!await CheckInBlacklist(clientId, tutorToSubj.Tutor.Id) &&
                !tutors.Contains(tutorToSubj.Tutor))
            {
                tutors.Add(tutorToSubj.Tutor);
            }
        }
        return tutors;
    }
}