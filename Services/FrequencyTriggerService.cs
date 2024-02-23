using Quartz;
using QuartzFrequencies.Background.Jobs;
using QuartzFrequencies.Services.Interfaces;

namespace QuartzFrequencies.Services;

public class FrequencyTriggerService : IFrequencyTriggerService
{
    private readonly ISchedulerFactory schedulerFactory;
    private readonly JobKey jobKey;
    private readonly IScheduler Scheduler;

    public FrequencyTriggerService(ISchedulerFactory schedulerFactory)
    {
        _ = schedulerFactory ?? throw new ArgumentNullException(nameof(schedulerFactory));
        jobKey = JobKey.Create(nameof(FrequencyTriggerJob));
        Scheduler = schedulerFactory.GetScheduler().GetAwaiter().GetResult();
        this.schedulerFactory = schedulerFactory;
    }

    public async Task<bool> CreateFrequencyAsync(int taskId, string cronExpression, CancellationToken cancellationToken)
    {
        if (await Scheduler.CheckExists(jobKey, cancellationToken))
        {
            var triggerKey = new TriggerKey(taskId.ToString(), "Group1");
            var trigger = TriggerBuilder.Create()
                .WithIdentity(triggerKey)
                .WithCronSchedule(cronExpression)
                .UsingJobData("TaskId", taskId)
                .ForJob(jobKey)
                .Build();

            await Scheduler.ScheduleJob(trigger, cancellationToken);
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteFrequencyAsync(int taskId, CancellationToken cancellationToken)
    {
        if (await Scheduler.CheckExists(jobKey, cancellationToken))
        {
            var triggerKey = new TriggerKey(taskId.ToString(), "Group1");
            await Scheduler.UnscheduleJob(triggerKey, cancellationToken);
            return true;
        }
        return false;
    }

    public async Task<IReadOnlyCollection<ITrigger>> GetFrequencyJobsAsync(CancellationToken cancellationToken)
    {
        if (await Scheduler.CheckExists(jobKey, cancellationToken))
            return await Scheduler.GetTriggersOfJob(jobKey, cancellationToken);
        return new List<ITrigger>();
    }

    public async Task<bool> UpdateFrequencyAsync(int taskId, string cronExpression, CancellationToken cancellationToken)
    {
        if (await Scheduler.CheckExists(jobKey, cancellationToken))
        {
            var triggerKey = new TriggerKey(taskId.ToString(), "Group1");
            var trigger = TriggerBuilder.Create()
                .WithIdentity(triggerKey)
                .WithCronSchedule(cronExpression)
                .UsingJobData("TaskId", taskId)
                .ForJob(jobKey)
                .Build();

            await Scheduler.RescheduleJob(triggerKey, trigger, cancellationToken);
            return true;
        }
        return false;
    }
}
