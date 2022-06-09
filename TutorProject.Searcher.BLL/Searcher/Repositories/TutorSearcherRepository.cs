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
    
    public async Task<Account.Common.Models.Blacklist?> CheckInBlacklist(Guid clientId, Guid tutorId)
    {
        return await _context.Blacklist.SingleOrDefaultAsync(ctt => ctt.Client.Id == clientId
                                                                    && ctt.Tutor.Id == tutorId);
    }
    
    public async Task<List<TutorToSubject>> Search(string? subject, WorkFormat? workFormat, int? minPrice, int? maxPrice, int? pupilClass)
    {
        minPrice ??= 0;
        maxPrice ??= Int32.MaxValue;
        var tutors = _context.TutorToSubjects.Where(t =>
            (subject == null || t.Subject.Name.ToLower() == subject.ToLower())
            && (workFormat == null || t.Tutor.WorkFormat == null || t.Tutor.WorkFormat == workFormat)
            && t.Tutor.PricePerHour >= minPrice && t.Tutor.PricePerHour <= maxPrice
            && (pupilClass == null || t.Tutor.PupilMinClass == null && t.Tutor.PupilMaxClass == null 
                                   || t.Tutor.PupilMinClass == null && t.Tutor.PupilMaxClass >= pupilClass
                                   || t.Tutor.PupilMinClass <= pupilClass && t.Tutor.PupilMaxClass == null
                                   || t.Tutor.PupilMinClass <= pupilClass && t.Tutor.PupilMaxClass >= pupilClass));
        return await tutors.ToListAsync();
    }
}