using TutorProject.Account.Common;
using TutorProject.Searcher.BLL.Favorites.Repositories;
using TutorProject.Searcher.BLL.TutorSchedule.Repositories;

namespace TutorProject.Searcher.BLL.Favorites.Services;

public class FavoritesService : IFavoritesService
{
    private readonly FavoritesRepository _repository;

    public FavoritesService(TutorContext context)
    {
        _repository = new FavoritesRepository(context);
    }
    
    public async Task<bool> AddTutorToFavorites(Guid clientId, Guid tutorId)
    {
        return await _repository.AddTutorToFavorites(clientId, tutorId);
    }

    public async Task<bool> DeleteTutorFromFavorites(Guid clientId, Guid tutorId)
    {
        return await _repository.DeleteTutorFromFavorites(clientId, tutorId);
    }
}