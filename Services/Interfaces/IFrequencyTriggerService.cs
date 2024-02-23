using Quartz;

namespace QuartzFrequencies.Services.Interfaces;

public interface IFrequencyTriggerService
{
    Task<IReadOnlyCollection<ITrigger>> GetFrequencyJobsAsync(CancellationToken cancellationToken);
    Task<bool> CreateFrequencyAsync(int taskId, string cronExpression, CancellationToken cancellationToken);
    Task<bool> DeleteFrequencyAsync(int taskId, CancellationToken cancellationToken);
    Task<bool> UpdateFrequencyAsync(int taskId, string cronExpression, CancellationToken cancellationToken);
}
