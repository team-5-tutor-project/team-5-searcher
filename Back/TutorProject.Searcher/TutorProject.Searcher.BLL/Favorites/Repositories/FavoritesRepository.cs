using Microsoft.EntityFrameworkCore;
using TutorProject.Account.Common;
using TutorProject.Account.Common.Models;

namespace TutorProject.Searcher.BLL.Favorites.Repositories;

public class FavoritesRepository
{
    private readonly TutorContext _context;

    public FavoritesRepository(TutorContext context)
    {
        _context = context;
        _context.Favorites
            .Include(sdl => sdl.Tutor)
            .Include(sdl => sdl.Client)
            .Load();
    }

    public async Task<bool> AddTutorToFavorites(Guid clientId, Guid tutorId)
    {
        var client = await _context.Clients.SingleOrDefaultAsync(cl => cl.Id == clientId);
        var tutor = await _context.Tutors.SingleOrDefaultAsync(t => t.Id == tutorId);
        var clientToTutor = await _context.Favorites.SingleOrDefaultAsync(ctt =>
            ctt.Client.Id == clientId && ctt.Tutor.Id == tutorId);

        if (client == null || tutor == null || clientToTutor != null)
        {
            return false;
        }

        var black = await _context.Blacklist.SingleOrDefaultAsync(ct => ct.Client.Id == clientId && ct.Tutor.Id == tutorId);
        if (black != null)
        {
            _context.Blacklist.Remove(black);
        }
        
        var fav = new Account.Common.Models.Favorites()
        {
            Id = Guid.NewGuid(),
            Client = client,
            Tutor = tutor
        };

        await _context.Favorites.AddAsync(fav);
        await _context.SaveChangesAsync();

        return true;
    }
    
    public async Task<bool> DeleteTutorFromFavorites(Guid clientId, Guid tutorId)
    {
        var clientToTutor = await _context.Favorites.SingleOrDefaultAsync(ctt =>
            ctt.Client.Id == clientId && ctt.Tutor.Id == tutorId);

        if (clientToTutor == null)
        {
            return false;
        }
        
        _context.Favorites.Remove(clientToTutor);
        await _context.SaveChangesAsync();
        
        return true;
    }
    
    public async Task<bool> CheckTutorInFavorites(Guid clientId, Guid tutorId)
    {
        var clientToTutor = await _context.Favorites.SingleOrDefaultAsync(ctt =>
            ctt.Client.Id == clientId && ctt.Tutor.Id == tutorId);
        if (clientToTutor == null)
        {
            return false;
        }

        return true;
    }
    public async Task<List<Account.Common.Models.Favorites>> GetTutorsFromFavorites(Guid clientId)
    {
        return await _context.Favorites.Where(ctt => ctt.Client.Id == clientId)
            .ToListAsync();
    }
}