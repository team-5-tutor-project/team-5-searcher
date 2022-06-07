using Microsoft.EntityFrameworkCore;
using TutorProject.Account.Common;
using TutorProject.Account.Common.Models;

namespace TutorProject.Searcher.BLL.DataSync.Repositories;

public class DataSyncRepository
{
    private readonly TutorContext _context;
    private readonly Random _random = new();
    private readonly WorkFormat[] _workFormatValues = Enum.GetValues(typeof(WorkFormat)).Cast<WorkFormat>().ToArray();
    private readonly string[] _tutorsNames = {"Sofia", "Svetlana", "Julia", "Alisa", "Valeria", "Alexandra", "Alexei"};
    private readonly string[] _clientsNames = {"Arina", "Milana", "Vera", "Diana", "Elena", "Karina", "Pavel"};
    private readonly string[] _subjectsNames = {"Math", "Informatics", "Python", "Pascal", "Robotics"};

    public DataSyncRepository(TutorContext context)
    {
        _context = context;
        _context.TutorToSubjects
            .Include(tts => tts.Subject)
            .Include(tts => tts.Tutor)
            .Load();
    }
    
    public async Task PostNewTutors(int numOfTutors)
    {
        for (int i = 0; i < numOfTutors; i++)
        {
            int pupilMaxClass = _random.Next(1, 11);
            
            var tutor = new Tutor
            {
                Id = Guid.NewGuid(),
                Name = _tutorsNames[_random.Next(_tutorsNames.Length)],
                WorkFormat = _workFormatValues[_random.Next(_workFormatValues.Length)],
                PricePerHour = _random.Next(2000),
                PupilMaxClass = pupilMaxClass,
                PupilMinClass = _random.Next(1, pupilMaxClass)
            };
            
            var subject = new Subject
            {
                Id = Guid.NewGuid(),
                Name = _subjectsNames[_random.Next(_subjectsNames.Length)]
            };
            
            var tutorToSubject = new TutorToSubject
           {
               Id = Guid.NewGuid(),
               Tutor = tutor,
               Subject = subject
           };
            await _context.TutorToSubjects.AddAsync(tutorToSubject);
            
            var newSchedule = new Schedule
            {
                Id = Guid.NewGuid(),
                Tutor = tutor
            };

            for (int j = 0; j < 7; j++)
            {
                newSchedule.FreeTimeSchedule.Add(new Day());
            }

            if (_random.Next(2) == 1)
            {
                for (int j = 0; j < 5; j++)
                {
                    newSchedule.FreeTimeSchedule[_random.Next(0, 6)].DaySchedule[_random.Next(0, 11)] = true;
                }
            }
            
            await _context.Schedules.AddAsync(newSchedule);
            
            await _context.SaveChangesAsync();
        }
    }

    public async Task PostNewClients(int numOfClients)
    {
        for (int i = 0; i < numOfClients; i++)
        {
            var client = new Client
            {
                Id = Guid.NewGuid(),
                Name = _clientsNames[_random.Next(_clientsNames.Length)]
            };
            await _context.Clients.AddAsync(client);
        
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task DeleteData()
    {
        foreach (var tutorToSubject in _context.TutorToSubjects)
        {
            _context.TutorToSubjects.Remove(tutorToSubject);
        }

        foreach (var day in _context.Days)
        {
            _context.Days.Remove(day);
        }
        
        foreach (var schedule in _context.Schedules)
        {
             _context.Schedules.Remove(schedule);
        }
        
        foreach (var tutor in _context.Tutors)
        {
            _context.Tutors.Remove(tutor);
        }
        
        foreach (var subject in _context.Subjects)
        {
            _context.Subjects.Remove(subject);
        }

        foreach (var client in _context.Clients)
        {
            _context.Clients.Remove(client);
        }

        
        await _context.SaveChangesAsync();
    }
}