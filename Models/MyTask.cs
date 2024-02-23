namespace QuartzFrequencies.Models;

public class MyTask
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string CronExpression { get; set; }
}
