namespace TutorProject.Searcher.BLL.DataSync.Services;

public interface IDataSyncService
{
    Task PostData(int numOfTutors);
    Task DeleteData();
}