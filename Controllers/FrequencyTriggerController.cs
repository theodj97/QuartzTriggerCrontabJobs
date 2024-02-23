using Microsoft.AspNetCore.Mvc;
using QuartzFrequencies.Models;
using QuartzFrequencies.Models.Requests.FrequencyTrigger;
using QuartzFrequencies.Services.Interfaces;

namespace QuartzFrequencies.Controllers;

[ApiController]
[Route("[controller]")]
public class FrequencyTriggerController : ControllerBase
{
    private readonly ILogger<FrequencyTriggerController> _logger;
    private readonly IFrequencyTriggerService frequencyService;

    public FrequencyTriggerController(ILogger<FrequencyTriggerController> logger, IFrequencyTriggerService frequencyService)
    {
        _logger = logger;
        this.frequencyService = frequencyService;
    }

    [HttpGet(Name = "GetFrequencyTriggerJobs")]
    public async Task<IActionResult> Get()
    {
        var result = await frequencyService.GetFrequencyJobsAsync(CancellationToken.None);
        return Ok(result);
    }

    [HttpPost(Name = "CreateFrequencyTriggerJob")]
    public async Task<IActionResult> Create([FromBody] CreateFrequencyTriggerRequest request)
    {
        var result = await frequencyService.CreateFrequencyAsync(request.TaskId, request.CronExpression, CancellationToken.None);
        return Ok(result);
    }

    [HttpPut(Name = "UpdateFrequencyTriggerJob/{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] UpdateFrequencyTriggerRequest request)
    {
        var validId = int.TryParse(id, out int taskId);
        if (!validId)
            return BadRequest("Invalid Id");

        var result = await frequencyService.UpdateFrequencyAsync(taskId, request.CronExpression, CancellationToken.None);
        return Ok(result);
    }


    [HttpDelete(Name = "DeleteFrequencyTriggerJob/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var validId = int.TryParse(id, out int taskId);
        if (!validId)
            return BadRequest("Invalid Id");

        var result = await frequencyService.DeleteFrequencyAsync(taskId, CancellationToken.None);
        return Ok(result);
    }
}
