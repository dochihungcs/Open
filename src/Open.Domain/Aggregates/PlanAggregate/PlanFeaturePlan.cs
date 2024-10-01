namespace Open.Domain.Aggregates.PlanAggregate;

public class PlanFeaturePlan
{
    public Guid Id { get; init; }
    public Guid PlanId { get; init; }
    public Guid FeatureId { get; init; }
    
    public bool IsIncluded { get; set; }
    
    public virtual Plan Plan { get; set; }
    public virtual PlanFeature Feature { get; set; }
}
