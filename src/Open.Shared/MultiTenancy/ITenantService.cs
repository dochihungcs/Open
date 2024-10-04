namespace Open.Shared.MultiTenancy;

public interface ITenantService
{
    Task<TenantConfiguration?> FindAsync(string normalizedName, CancellationToken cancellationToken = default);

    Task<TenantConfiguration?> FindAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<TenantConfiguration>> GetListAsync(bool includeDetails = false, CancellationToken cancellationToken = default);
}
