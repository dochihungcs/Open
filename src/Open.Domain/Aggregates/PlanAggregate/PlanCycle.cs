namespace Open.Domain.Aggregates.PlanAggregate;

public class PlanCycle
{
    public Guid Id { get; set; }
    
    public CycleLength Duration { get; set; }
    public DurationUnit DurationUnit { get; set; } 
    
    public virtual Plan Plan { get; set; }
}
