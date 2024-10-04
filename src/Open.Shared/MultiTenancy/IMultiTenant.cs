namespace Open.Shared.MultiTenancy;

public interface IMultiTenant
{
    Guid? TenantId { get; }
}
