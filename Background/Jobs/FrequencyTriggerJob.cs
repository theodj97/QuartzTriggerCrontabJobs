using Quartz;

namespace QuartzFrequencies.Background.Jobs;

// Esta nota hace referencia a que sólo se puede ejecutar una instancia de este trabajo a la vez, si el trabajo no ha terminado en el intervalo de tiempo seleccionado, no se ejecutará una nueva instancia.
[DisallowConcurrentExecution]
public class FrequencyTriggerJob(ILogger<FrequencyTriggerJob> logger) : IJob
{
    private readonly ILogger<FrequencyTriggerJob> logger = logger;

    public Task Execute(IJobExecutionContext context)
    {
        var dataMap = context.MergedJobDataMap;
        var taskId = (int)dataMap["TaskId"];

        logger.LogInformation("(LOGGER)Frequency job is executing at: {Timestamp} and has TaskId: {value}", DateTime.UtcNow.ToString(), taskId);
        return Task.CompletedTask;
    }
}