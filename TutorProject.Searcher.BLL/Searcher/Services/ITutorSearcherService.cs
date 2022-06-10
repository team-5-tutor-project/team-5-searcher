using TutorProject.Account.Common.Models;

namespace TutorProject.Searcher.BLL.Searcher.Services;

public interface ITutorSearcherService
{
    Task<List<Tutor>> GetAll(Guid clientId);

    Task<List<Tutor>> Search(Guid clientId, string? subject, WorkFormat? workFormat, int? minPrice,
        int? maxPrice, int? pupilClass, List<bool>? schedule, TutorsOrder? tutorsOrder);
}