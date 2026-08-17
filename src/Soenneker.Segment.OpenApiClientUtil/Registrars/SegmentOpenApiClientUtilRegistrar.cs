using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Segment.HttpClients.Registrars;
using Soenneker.Segment.OpenApiClientUtil.Abstract;

namespace Soenneker.Segment.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class SegmentOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="SegmentOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddSegmentOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddSegmentOpenApiHttpClientAsSingleton()
                .TryAddSingleton<ISegmentOpenApiClientUtil, SegmentOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="SegmentOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddSegmentOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddSegmentOpenApiHttpClientAsSingleton()
                .TryAddScoped<ISegmentOpenApiClientUtil, SegmentOpenApiClientUtil>();

        return services;
    }
}
