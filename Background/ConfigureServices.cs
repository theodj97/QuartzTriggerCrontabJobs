using Quartz;
using QuartzFrequencies.Background.Jobs;
using QuartzFrequencies.Models;

namespace QuartzFrequencies.Background;

public static class ConfigureServices
{
    public static void AddBackgroundServices(this IServiceCollection services)
    {
        services.AddQuartz(opts =>
        {
            MyTask firstTask = new()
            {
                Id = 1,
                Name = "task1",
                Description = "This is the first task",
                CronExpression = "0/5 * * * * ?"
            };

            var triggerDictionary = new Dictionary<string, int>
            {
                { "TaskId", firstTask.Id }
            };

            TriggerKey triggerKey = new("1", "Group1");
            JobKey jobKey = JobKey.Create(nameof(FrequencyTriggerJob));

            // Adding a default job
            opts.AddJob<FrequencyTriggerJob>(jobBuilder => jobBuilder.WithIdentity(jobKey))
                .AddTrigger(triggerBuilder => triggerBuilder
                .WithIdentity(triggerKey)
                .WithCronSchedule(firstTask.CronExpression)
                .UsingJobData(new JobDataMap(triggerDictionary))
                .ForJob(jobKey));
        });

        services.AddQuartzHostedService();
    }
}
