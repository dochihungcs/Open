namespace Open.Domain.Aggregates.PlanAggregate;

public class PlanFeature
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public bool IsActive { get; init; }
}
