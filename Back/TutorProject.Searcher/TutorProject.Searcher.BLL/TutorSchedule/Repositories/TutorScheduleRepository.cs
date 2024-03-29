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
        var existingSchedule = await _context.Schedules.SingleOrDefaultAsync(sdl => sdl.Tutor.Id == tutorId);

        if (existingSchedule is not null)
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
        } 
        
        await _context.AddAsync(newSchedule);
        await _context.SaveChangesAsync();

        return newSchedule;
    }

    public async Task<Schedule?> SetAllTimeFree(Guid tutorId)
    {
        var schedule = await _context.Schedules.SingleOrDefaultAsync(sdl => sdl.Tutor.Id == tutorId);
        
        if (schedule == null)
            return null;
        
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

    public async Task<Schedule?> AddFreeTime(Guid tutorId, int dayOfWeek, int lessonNumber)
    {
        var schedule = await _context.Schedules.SingleOrDefaultAsync(sdl => sdl.Tutor.Id == tutorId);

        if (schedule == null)
            return null;
        
        schedule.FreeTimeSchedule[dayOfWeek].DaySchedule[lessonNumber] = true;
        
        await _context.SaveChangesAsync();
        
        return schedule;
    }

    public async Task<Schedule?> GetTutorSchedule(Guid tutorId)
    {
        var schedule = await _context.Schedules.SingleOrDefaultAsync(x => x.Tutor.Id == tutorId);
        
        return schedule;
    }

    public async Task<Schedule?> SetAllTimeTaken(Guid tutorId)
    {
        var schedule = await _context.Schedules.SingleOrDefaultAsync(x => x.Tutor.Id == tutorId);

        if (schedule == null)
            return null;
        
        foreach (var day in schedule.FreeTimeSchedule)
        {
            for (int i = 0; i < day.DaySchedule.Count; i++)
            {
                day.DaySchedule[i] = false;
            }
        }
        
        await _context.SaveChangesAsync();

        return schedule;
    }
    
    public async Task<Schedule?> SetTimeTaken(Guid tutorId, int dayOfWeek, int lessonNumber)
    {
        var schedule = await _context.Schedules.SingleOrDefaultAsync(x => x.Tutor.Id == tutorId);

        if (schedule == null)
            return null;
        
        schedule.FreeTimeSchedule[dayOfWeek].DaySchedule[lessonNumber] = false;
        
        await _context.SaveChangesAsync();

        return schedule;
    }

    public async Task<bool> DeleteSchedule(Guid tutorId)
    {
        var schedule = await _context.Schedules.SingleOrDefaultAsync(x => x.Tutor.Id == tutorId);

        if (schedule == null)
            return false;
        
        _context.Schedules.Remove(schedule);

        for (int i = 0; i < schedule.FreeTimeSchedule.Count; i++)
        {
            _context.Days.Remove(schedule.FreeTimeSchedule[i]);
        }
        
        await _context.SaveChangesAsync();

        return true;
    }
}