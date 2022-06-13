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

    [HttpPost("createNewTutors")]
    public async Task<IActionResult> PostNewTutors([FromQuery] int numOfTutors)
    {
        await _service.PostNewTutors(numOfTutors);
        return Ok();
    }
    
    [HttpPost("createNewClients")]
    public async Task<IActionResult> PostNewClients([FromQuery] int numOfClients)
    {
        await _service.PostNewClients(numOfClients);
        return Ok();
    }
    
    [HttpDelete("deleteData")]
    public async Task<IActionResult> Delete()
    {
        await _service.DeleteData();
        return Ok();
    }
}