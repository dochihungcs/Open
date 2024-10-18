using Microsoft.Extensions.DependencyInjection;

namespace Open.Shared.DependencyInjection;

public static class ServiceProviderKeyedServiceExtensions
{
    public static object? GetKeyedService(this IServiceProvider provider, Type serviceType, object? serviceKey)
    {
        Guard.Against.Null(provider, nameof(provider));

        if (provider is IKeyedServiceProvider keyedServiceProvider)
        {
            return keyedServiceProvider.GetKeyedService(serviceType, serviceKey);
        }

        throw new InvalidOperationException("This service provider doesn't support keyed services.");
    }
}
