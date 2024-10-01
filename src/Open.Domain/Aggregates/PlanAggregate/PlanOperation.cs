namespace Open.Domain.Aggregates.PlanAggregate;

public class PlanOperation
{
    public Guid Id { get; init; }
    
    public Guid PlanId { get; init; }
    
    public RequestType RequestType { get; init; }
    
    public long MaxRequests { get; init; }
    
    public int CurrentUsage { get; set; }
    
    public virtual Plan Plan { get; init; }
}
