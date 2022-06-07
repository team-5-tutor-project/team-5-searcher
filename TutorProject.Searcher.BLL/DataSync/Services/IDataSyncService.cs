namespace TutorProject.Searcher.BLL.DataSync.Services;

public interface IDataSyncService
{
    Task PostNewTutors(int numOfTutors);
    Task PostNewClients(int numOfClients);
    
    Task DeleteData();
}