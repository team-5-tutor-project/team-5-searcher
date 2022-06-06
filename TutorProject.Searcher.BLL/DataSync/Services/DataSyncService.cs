using TutorProject.Account.Common;
using TutorProject.Searcher.BLL.DataSync.Repositories;

namespace TutorProject.Searcher.BLL.DataSync.Services;

public class DataSyncService : IDataSyncService
{
    private readonly DataSyncRepository _repository;
    
    public DataSyncService(TutorContext context)
    {
        _repository = new DataSyncRepository(context);
    }

    public async Task PostData(int numOfTutors)
    {
        await _repository.PostData(numOfTutors);
    }

    public async Task DeleteData()
    {
        await _repository.DeleteData();
    }
}