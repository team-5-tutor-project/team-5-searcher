using TutorProject.Account.Common.Models;

namespace TutorProject.Searcher.BLL.Services;

public interface ITutorSearcherService
{
    Task<List<Tutor>> GetAll();

    Task<List<TutorToSubject>> Search(string? subject, WorkFormat? workFormat, int? minPrice,
        int? maxPrice, int? pupilClass);
}