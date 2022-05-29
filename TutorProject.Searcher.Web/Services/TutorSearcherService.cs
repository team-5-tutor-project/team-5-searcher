using TutorProject.Account.Common;
using TutorProject.Account.Common.Models;
using TutorProject.Searcher.Web.Repositories;

namespace TutorProject.Searcher.Web.Services;

public class TutorSearcherService
{
    private readonly TutorSearcherRepository _repository;

    public TutorSearcherService(TutorContext context)
    {
        _repository = new TutorSearcherRepository(context);
    }

    public List<Tutor> GetAll()
    {
        return _repository.GetAll();
    }
    
    public List<TutorToSubject> Search(string? subject, WorkFormat? workFormat, int? minPrice,
        int? maxPrice, int? pupilClass)
    {
        return _repository.Search(subject, workFormat, minPrice, maxPrice, pupilClass);
    }
}