using TutorProject.Account.Common;
using TutorProject.Account.Common.Models;
using TutorProject.Searcher.BLL.Repositories;

namespace TutorProject.Searcher.BLL.Services;

public class TutorSearcherService : ITutorSearcherService
{
    private readonly TutorSearcherRepository _repository;

    public TutorSearcherService(TutorContext context)
    {
        _repository = new TutorSearcherRepository(context);
    }

    public async Task<List<Tutor>> GetAll()
    {
        return await _repository.GetAll();
    }
    
    public async Task<List<TutorToSubject>> Search(string? subject, WorkFormat? workFormat, int? minPrice,
        int? maxPrice, int? pupilClass)
    {
        return await _repository.Search(subject, workFormat, minPrice, maxPrice, pupilClass);
    }
}