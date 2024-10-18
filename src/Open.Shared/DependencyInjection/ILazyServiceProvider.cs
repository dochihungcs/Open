namespace Open.Shared.DependencyInjection;

public interface ILazyServiceProvider
{
    /// <summary>
    /// This method is equivalent of the GetRequiredService method.
    /// It does exists for backward compatibility.
    /// </summary>
    T LazyGetRequiredService<T>();

    /// <summary>
    /// This method is equivalent of the GetRequiredService method.
    /// It does exists for backward compatibility.
    /// </summary>
    object LazyGetRequiredService(Type serviceType);

    /// <summary>
    /// This method is equivalent of the GetService method.
    /// It does exists for backward compatibility.
    /// </summary>
    T? LazyGetService<T>();

    /// <summary>
    /// This method is equivalent of the GetService method.
    /// It does exists for backward compatibility.
    /// </summary>
    object? LazyGetService(Type serviceType);

    /// <summary>
    /// This method is equivalent of the <see cref="ICachedServiceProvider.GetService{T}(T)"/> method.
    /// It does exists for backward compatibility.
    /// </summary>
    T LazyGetService<T>(T defaultValue);
    
    /// <summary>
    /// This method is equivalent of the <see cref="ICachedServiceProvider.GetService(Type, object)"/> method.
    /// It does exists for backward compatibility.
    /// </summary>
    object LazyGetService(Type serviceType, object defaultValue);

    /// <summary>
    /// This method is equivalent of the <see cref="ICachedServiceProvider.GetService(Type, Func{IServiceProvider, object})"/> method.
    /// It does exists for backward compatibility.
    /// </summary>
    object LazyGetService(Type serviceType, Func<IServiceProvider, object> factory);

    /// <summary>
    /// This method is equivalent of the <see cref="ICachedServiceProvider.GetService{T}(Func{IServiceProvider, object})"/> method.
    /// It does exists for backward compatibility.
    /// </summary>
    T LazyGetService<T>(Func<IServiceProvider, object> factory);
}
