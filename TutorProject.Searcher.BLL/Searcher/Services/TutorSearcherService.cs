using TutorProject.Account.Common;
using TutorProject.Account.Common.Models;
using TutorProject.Searcher.BLL.Blacklist.Repositories;
using TutorProject.Searcher.BLL.Searcher.Repositories;
using TutorProject.Searcher.BLL.TutorSchedule.Repositories;

namespace TutorProject.Searcher.BLL.Searcher.Services;

public class TutorSearcherService : ITutorSearcherService
{
    private readonly TutorSearcherRepository _repository;
    private readonly TutorScheduleRepository _scheduleRepository;

    public TutorSearcherService(TutorContext context)
    {
        _repository = new TutorSearcherRepository(context);
        _scheduleRepository = new TutorScheduleRepository(context);
    }

    public async Task<List<Tutor>> GetAll(Guid clientId)
    {
        var tutors = await _repository.GetAll();
        var tutorsToRemove = new List<Tutor>();
        
        foreach (var tutor in tutors)
        {
            if (await CheckInBlacklist(clientId, tutor.Id) || !await CheckSchedule(tutor.Id, null))
            {
                tutorsToRemove.Add(tutor);
            }
        }
        
        foreach (var tutor in tutorsToRemove)
        {
            tutors.Remove(tutor);
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

    private async Task<bool> CheckSchedule(Guid tutorId, List<bool>? schedule)
    {
        var tutorSchedule = await _scheduleRepository.GetTutorSchedule(tutorId);

        for (int i = 0; i < tutorSchedule.FreeTimeSchedule.Count; i++)
        {
            if (tutorSchedule.FreeTimeSchedule[i].DaySchedule.Contains(true))
            {
                break;
            }

            if (i == tutorSchedule.FreeTimeSchedule.Count - 1)
            {
                return false;
            }
        }
        if (schedule == null || !schedule.Contains(true))
        {
            return true;
        }
        
        for (int i = 0; i < schedule.Count; i++)
        {
            if (schedule[i] && tutorSchedule.FreeTimeSchedule[i].DaySchedule.Contains(true))
            {
                return true;
            }
        }
        
        return false;
    }
    
    public async Task<List<Tutor>> Search(Guid clientId, string? subject, WorkFormat? workFormat, int? minPrice,
        int? maxPrice, int? pupilClass, List<bool>? schedule, TutorsOrder? tutorsOrder)
    {
        var tutorsToSubject = await _repository.Search(subject, workFormat, minPrice, maxPrice, pupilClass, tutorsOrder);
        var tutors = new List<Tutor>();
        foreach (var tutorToSubj in tutorsToSubject)
        {
            if (!await CheckInBlacklist(clientId, tutorToSubj.Tutor.Id) &&
                !tutors.Contains(tutorToSubj.Tutor) &&
                await CheckSchedule(tutorToSubj.Tutor.Id, schedule))
            {
                tutors.Add(tutorToSubj.Tutor);
            }
        }
        return tutors;
    }
}