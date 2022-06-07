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

    public async Task PostNewTutors(int numOfTutors)
    {
        await _repository.PostNewTutors(numOfTutors);
    }
    
    public async Task PostNewClients(int numOfClients)
    {
        await _repository.PostNewClients(numOfClients);
    }

    public async Task DeleteData()
    {
        await _repository.DeleteData();
    }
}