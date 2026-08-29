using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.Dtos.HttpClientOptions;
using Soenneker.Extensions.Configuration;
using Soenneker.Sabnzbd.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Sabnzbd.HttpClients;

/// <inheritdoc cref="ISabnzbdOpenApiHttpClient"/>
public sealed class SabnzbdOpenApiHttpClient : ISabnzbdOpenApiHttpClient
{
    private readonly IHttpClientCache _httpClientCache;
    private readonly IConfiguration _config;

    private const string _defaultBaseUrl = "http://localhost:8080";

    public SabnzbdOpenApiHttpClient(IHttpClientCache httpClientCache, IConfiguration config)
    {
        _httpClientCache = httpClientCache;
        _config = config;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        return _httpClientCache.Get(nameof(SabnzbdOpenApiHttpClient), _config.GetString("Sabnzbd:ClientBaseUrl") ?? _defaultBaseUrl, static baseUrl =>
        {
            return new HttpClientOptions
            {
                BaseAddress = new Uri(baseUrl, UriKind.Absolute)
            };
        }, cancellationToken);
    }

    public void Dispose()
    {
        _httpClientCache.RemoveSync(nameof(SabnzbdOpenApiHttpClient));
    }

    public ValueTask DisposeAsync()
    {
        return _httpClientCache.Remove(nameof(SabnzbdOpenApiHttpClient));
    }
}
