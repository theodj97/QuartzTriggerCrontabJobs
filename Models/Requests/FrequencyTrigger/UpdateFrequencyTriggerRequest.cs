namespace QuartzFrequencies.Models.Requests.FrequencyTrigger;

public class UpdateFrequencyTriggerRequest
{
    public required string CronExpression { get; set; }
}
