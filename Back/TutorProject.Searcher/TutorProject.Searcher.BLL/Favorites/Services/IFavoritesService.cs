using TutorProject.Account.Common.Models;

namespace TutorProject.Searcher.BLL.Favorites.Services;

public interface IFavoritesService
{
     Task<bool> AddTutorToFavorites(Guid clientId, Guid tutorId);

     Task<bool> DeleteTutorFromFavorites(Guid clientId, Guid tutorId);

     Task<bool> CheckTutorInFavorites(Guid clientId, Guid tutorId);
     
     Task<List<Tutor>> GetTutorsFromFavorites(Guid clientId);
}