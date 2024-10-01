namespace Open.Domain.Aggregates.PlanAggregate;

public class Plan
{
    public Guid Id { get; init; }
    
    public string Name { get; init; }
    
    public string Description { get; init; }
    
    public long MaxCapacity { get; init; }
    public long MaxFileCount { get; init; }
    
    public bool IsActive { get; set; }
    
    
    public virtual PlanCycle Cycle { get; set; }
    public virtual PlanPricing Pricing { get; set; }
    public ICollection<PlanFeaturePlan> Features { get; set; }
}
