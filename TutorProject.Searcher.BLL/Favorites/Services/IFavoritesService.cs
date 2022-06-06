namespace TutorProject.Searcher.BLL.Favorites.Services;

public interface IFavoritesService
{
     Task<bool> AddTutorToFavorites(Guid clientId, Guid tutorId);

     Task<bool> DeleteTutorFromFavorites(Guid clientId, Guid tutorId);
}