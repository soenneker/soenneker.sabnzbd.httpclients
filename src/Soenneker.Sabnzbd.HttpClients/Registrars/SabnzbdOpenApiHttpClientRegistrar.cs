using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Sabnzbd.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Sabnzbd.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAPI HttpClient wrapper for dependency injection.
/// </summary>
public static class SabnzbdOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="SabnzbdOpenApiHttpClient"/> as a singleton service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddSabnzbdOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<ISabnzbdOpenApiHttpClient, SabnzbdOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="SabnzbdOpenApiHttpClient"/> as a scoped service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddSabnzbdOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<ISabnzbdOpenApiHttpClient, SabnzbdOpenApiHttpClient>();

        return services;
    }
}
