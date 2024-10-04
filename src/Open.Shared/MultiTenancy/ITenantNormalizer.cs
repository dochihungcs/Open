namespace Open.Shared.MultiTenancy;

public interface ITenantNormalizer
{
    string? NormalizeName(string? name);
}
