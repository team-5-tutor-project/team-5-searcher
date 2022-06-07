using TutorProject.Account.Common;
using TutorProject.Account.Common.Models;
using TutorProject.Searcher.BLL.Favorites.Repositories;

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

    public async Task<List<Tutor>> GetTutorsFromFavorites(Guid clientId)
    {
        var clientToTutor = await _repository.GetTutorsFromFavorites(clientId);
        var tutors = new List<Tutor>();
        foreach (var clientTutor in clientToTutor)
        {
            tutors.Add(clientTutor.Tutor);
        }

        return tutors;
    }
}