namespace Open.Shared.MultiTenancy;

public sealed class BasicTenantInfo
{
    public Guid? TenantId { get; }
    
    public string? Name { get; }

    public BasicTenantInfo(Guid? tenantId, string? name = null)
    {
        TenantId = tenantId;
        Name = name;
    }
}
