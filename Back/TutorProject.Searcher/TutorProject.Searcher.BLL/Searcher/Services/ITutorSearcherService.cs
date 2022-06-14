using TutorProject.Account.Common.Models;
using TutorProject.Searcher.BLL.Data;

namespace TutorProject.Searcher.BLL.Searcher.Services;

public interface ITutorSearcherService
{
    Task<List<Tutor>> GetAll(Guid clientId);

    Task<List<string>> GetSubjectsForTutor(Guid tutorId);

    Task<List<Tutor>> Search(Guid clientId, SearcherData searcherData);
}