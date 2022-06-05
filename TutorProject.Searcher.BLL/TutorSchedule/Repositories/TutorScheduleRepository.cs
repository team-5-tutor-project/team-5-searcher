using Microsoft.EntityFrameworkCore;
using TutorProject.Account.Common;
using TutorProject.Account.Common.Models;

namespace TutorProject.Searcher.BLL.TutorSchedule.Repositories;

public class TutorScheduleRepository
{
    private readonly TutorContext _context;

    public TutorScheduleRepository(TutorContext context)
    {
        _context = context;
        _context.Schedules
            .Include(sdl => sdl.Tutor)
            .Include(sdl => sdl.FreeTimeSchedule)
            .Load();
    }

    public async Task<Schedule?> AddSchedule(Guid tutorId)
    {
        if (_context.Schedules.ToList().Any(sdl => sdl.Tutor.Id == tutorId))
        {
            return null;
        }
        
        var newSchedule = new Schedule()
        {
            Id = Guid.NewGuid(),
            Tutor = await _context.Tutors.FindAsync(tutorId)
        };

        for (int i = 0; i < 7; i++)
        {
            newSchedule.FreeTimeSchedule.Add(new Day());
            newSchedule.FreeTimeSchedule[i].DayOfWeek = (DayOfWeek) i;
        }
        await _context.AddAsync(newSchedule);
        await _context.SaveChangesAsync();

        return newSchedule;
    }

    public async Task<Schedule?> SetAllTimeFree(Guid tutorId)
    {
        if (_context.Schedules.ToList().All(sdl => sdl.Tutor.Id != tutorId))
        {
            return null;
        }

        var schedule = await _context.Schedules.SingleOrDefaultAsync(x => x.Tutor.Id == tutorId);
        
        foreach (var day in schedule.FreeTimeSchedule)
        {
            for (int i = 0; i < day.DaySchedule.Count; i++)
            {
                day.DaySchedule[i] = true;
            }
        }

        await _context.SaveChangesAsync();

        return schedule;
    }

    public async Task<Schedule?> AddFreeTime(Guid tutorId, DayOfWeek dayOfWeek, int lessonNumber)
    {
        if (_context.Schedules.ToList().All(sdl => sdl.Tutor.Id != tutorId))
        {
            return null;
        }
        
        var schedule = await _context.Schedules.SingleOrDefaultAsync(x => x.Tutor.Id == tutorId);

        schedule.FreeTimeSchedule[(int) dayOfWeek].DaySchedule[lessonNumber - 1] = true;
        return schedule;
    }
    
    public async Task<List<Schedule>> GetAllSchedules()
    {
        return await _context.Schedules.ToListAsync();
    }
    
    public async Task<Schedule> GetTutorSchedule(Guid tutorId)
    {
        var schedule = await _context.Schedules.SingleOrDefaultAsync(x => x.Tutor.Id == tutorId);

        if (schedule == null)
            return null;

        return schedule;
    }
}