using Microsoft.EntityFrameworkCore;
using TutorProject.Account.Common;
using TutorProject.Account.Common.Models;

namespace TutorProject.Searcher.BLL.Searcher.Repositories;

public class TutorSearcherRepository
{
    private readonly TutorContext _context;

    public TutorSearcherRepository(TutorContext context)
    {
        _context = context;
        _context.TutorToSubjects
            .Include(tts => tts.Subject)
            .Include(tts => tts.Tutor)
            .Load();
    }
    public async Task<List<Tutor>> GetAll()
    {
        return await _context.Tutors.ToListAsync();
    }
    
    public async Task<List<TutorToSubject>> GetSubjectsForTutor(Guid tutorId)
    {
        return await _context.TutorToSubjects.Where(ts => ts.Tutor.Id == tutorId).ToListAsync();
    }
    
    public async Task<Account.Common.Models.Blacklist?> CheckInBlacklist(Guid clientId, Guid tutorId)
    {
        return await _context.Blacklist.SingleOrDefaultAsync(ctt => ctt.Client.Id == clientId
                                                                    && ctt.Tutor.Id == tutorId);
    }
    
    public async Task<List<TutorToSubject>> Search(string? subject, WorkFormat? workFormat, int? minPrice, int? maxPrice, int? pupilClass, TutorsOrder? tutorsOrder)
    {
        minPrice ??= 0;
        maxPrice ??= Int32.MaxValue;
        var tutors = new List<TutorToSubject>();
        switch (tutorsOrder)
        {
            case TutorsOrder.RisingPrice:
                tutors = await _context.TutorToSubjects.Where(t =>
                    (subject == null || t.Subject.Name.ToLower() == subject.ToLower())
                    && (workFormat == null || t.Tutor.WorkFormat == null || t.Tutor.WorkFormat == workFormat)
                    && (t.Tutor.PricePerHour == 0 || t.Tutor.PricePerHour >= minPrice && t.Tutor.PricePerHour <= maxPrice)
                    && (pupilClass == null || t.Tutor.PupilMinClass == 0 && t.Tutor.PupilMaxClass == 0
                                           || t.Tutor.PupilMinClass == 0 && t.Tutor.PupilMaxClass >= pupilClass
                                           || t.Tutor.PupilMinClass <= pupilClass && t.Tutor.PupilMaxClass == 0
                                           || t.Tutor.PupilMinClass <= pupilClass && t.Tutor.PupilMaxClass >= pupilClass)).OrderBy(t => t.Tutor.PricePerHour).ToListAsync();
                break;
            case TutorsOrder.DownwardPrice:
                tutors = await _context.TutorToSubjects.Where(t =>
                    (subject == null || t.Subject.Name.ToLower() == subject.ToLower())
                    && (workFormat == null || t.Tutor.WorkFormat == null || t.Tutor.WorkFormat == workFormat)
                    && (t.Tutor.PricePerHour == 0 || t.Tutor.PricePerHour >= minPrice && t.Tutor.PricePerHour <= maxPrice)
                    && (pupilClass == null || t.Tutor.PupilMinClass == 0 && t.Tutor.PupilMaxClass == 0
                                           || t.Tutor.PupilMinClass == 0 && t.Tutor.PupilMaxClass >= pupilClass
                                           || t.Tutor.PupilMinClass <= pupilClass && t.Tutor.PupilMaxClass == 0
                                           || t.Tutor.PupilMinClass <= pupilClass && t.Tutor.PupilMaxClass >= pupilClass)).OrderByDescending(t => t.Tutor.PricePerHour).ToListAsync();
                break;
            default:
                tutors = await _context.TutorToSubjects.Where(t =>
                    (subject == null || t.Subject.Name.ToLower() == subject.ToLower())
                    && (workFormat == null || t.Tutor.WorkFormat == null || t.Tutor.WorkFormat == workFormat)
                    && (t.Tutor.PricePerHour == 0 || t.Tutor.PricePerHour >= minPrice && t.Tutor.PricePerHour <= maxPrice)
                    && (pupilClass == null || t.Tutor.PupilMinClass == 0 && t.Tutor.PupilMaxClass == 0
                                           || t.Tutor.PupilMinClass == 0 && t.Tutor.PupilMaxClass >= pupilClass
                                           || t.Tutor.PupilMinClass <= pupilClass && t.Tutor.PupilMaxClass == 0
                                           || t.Tutor.PupilMinClass <= pupilClass && t.Tutor.PupilMaxClass >= pupilClass)).ToListAsync();
                break;
        }
        
        return tutors;
    }
}