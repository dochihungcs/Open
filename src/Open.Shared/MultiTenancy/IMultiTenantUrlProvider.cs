namespace Open.Shared.MultiTenancy;

public interface IMultiTenantUrlProvider
{
    Task<string> GetUrlAsync(string templateUrl);
}
