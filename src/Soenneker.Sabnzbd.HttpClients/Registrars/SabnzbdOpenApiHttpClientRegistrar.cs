using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Configuration;
using Soenneker.Sabnzbd.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Abstract;
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
                .TryAddSingleton<ISabnzbdOpenApiHttpClient>(provider =>
                    new SabnzbdOpenApiHttpClient(
                        provider.GetRequiredService<IHttpClientCache>(),
                        provider.GetRequiredService<IConfiguration>(),
                        true));

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
                .TryAddScoped<ISabnzbdOpenApiHttpClient>(provider =>
                    new SabnzbdOpenApiHttpClient(
                        provider.GetRequiredService<IHttpClientCache>(),
                        provider.GetRequiredService<IConfiguration>(),
                        false));

        return services;
    }
}
