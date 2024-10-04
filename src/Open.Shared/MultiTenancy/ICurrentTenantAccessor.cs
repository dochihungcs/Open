namespace Open.Shared.MultiTenancy;

public interface ICurrentTenantAccessor
{
    BasicTenantInfo? Current { get; set; }
}
