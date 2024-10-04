using Open.Shared.Data;

namespace Open.Shared.MultiTenancy;

[Serializable]
public class TenantConfiguration
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string NormalizedName { get; set; } = default!;

    public ConnectionStrings? ConnectionStrings { get; set; }

    public bool IsActive { get; set; }

    public TenantConfiguration()
    {
        IsActive = true;
    }

    public TenantConfiguration(Guid id, [NotNull] string name)
        : this()
    {
        Guard.Against.NullOrEmpty(name, nameof(name));

        Id = id;
        Name = name;

        ConnectionStrings = new ConnectionStrings();
    }

    public TenantConfiguration(Guid id, [NotNull] string name, [NotNull] string normalizedName)
        : this(id, name)
    {
        Guard.Against.NullOrEmpty(normalizedName, nameof(normalizedName));

        NormalizedName = normalizedName;
    }
}
