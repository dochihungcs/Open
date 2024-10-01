namespace Open.Domain.Aggregates.PlanAggregate;

public class PlanPricing
{
    public Guid Id { get; init; }
    public Guid PlanId { get; init; }
    public Guid PlanCycleId { get; init; }
    public decimal Price { get; init; }
    public Currency Currency { get; set; }
    
    public bool IsActive { get; set; }
    
    public virtual Plan Plan { get; set; }
}
