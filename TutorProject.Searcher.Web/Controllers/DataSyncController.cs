using Microsoft.AspNetCore.Mvc;
using TutorProject.Account.Common;
using TutorProject.Searcher.BLL.DataSync.Services;

namespace TutorProject.Searcher.Web.Controllers;

[ApiController]
[Route("/searcher/sync")]
public class DataSyncController : ControllerBase
{
    private readonly IDataSyncService _service;
    
    public DataSyncController(TutorContext context)
    {
        _service = new DataSyncService(context);
    }

    [HttpPost("createData")]
    public async Task PostData([FromQuery] int numOfTutors)
    {
        await _service.PostData(numOfTutors);
    }
    
    [HttpDelete("deleteData")]
    public async Task<IActionResult> Delete()
    {
        await _service.DeleteData();
        return Ok();
    }
}