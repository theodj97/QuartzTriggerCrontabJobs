namespace QuartzFrequencies.Models.Requests.FrequencyTrigger;

public class CreateFrequencyTriggerRequest
{
    public required int TaskId { get; set; }
    public required string CronExpression { get; set; }
}
