using Microsoft.EntityFrameworkCore;
using TutorProject.Account.Common;

namespace TutorProject.Searcher.BLL.Blacklist.Repositories;

public class BlacklistRepository
{
    private readonly TutorContext _context;

    public BlacklistRepository(TutorContext context)
    {
        _context = context;
        _context.Blacklist
            .Include(sdl => sdl.Tutor)
            .Include(sdl => sdl.Client)
            .Load();
    }

    public async Task<bool> AddTutorToBlacklist(Guid clientId, Guid tutorId)
    {
        var client = await _context.Clients.SingleOrDefaultAsync(cl => cl.Id == clientId);
        var tutor = await _context.Tutors.SingleOrDefaultAsync(t => t.Id == tutorId);
        var clientToTutor = await _context.Blacklist.SingleOrDefaultAsync(ctt =>
            ctt.Client.Id == clientId && ctt.Tutor.Id == tutorId);

        if (client == null || tutor == null || clientToTutor != null)
        {
            return false;
        }

        var fav =
            await _context.Favorites.SingleOrDefaultAsync(ct => ct.Client.Id == clientId && ct.Tutor.Id == tutorId);
        if ( fav != null)
        {
            _context.Favorites.Remove(fav);
        }
        
        var black = new Account.Common.Models.Blacklist()
        {
            Id = Guid.NewGuid(),
            Client = client,
            Tutor = tutor
        };

        await _context.Blacklist.AddAsync(black);
        await _context.SaveChangesAsync();

        return true;
    }
    
    public async Task<bool> DeleteTutorFromBlacklist(Guid clientId, Guid tutorId)
    {
        var clientToTutor = await _context.Blacklist.SingleOrDefaultAsync(ctt =>
            ctt.Client.Id == clientId && ctt.Tutor.Id == tutorId);

        if (clientToTutor == null)
        {
            return false;
        }
        
        _context.Blacklist.Remove(clientToTutor);
        await _context.SaveChangesAsync();
        
        return true;
    }
    
    public async Task<List<Account.Common.Models.Blacklist>> GetTutorsFromBlacklist(Guid clientId)
    {
        return await _context.Blacklist.Where(ctt => ctt.Client.Id == clientId)
            .ToListAsync();
    }
}