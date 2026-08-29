using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Sabnzbd.HttpClients.Abstract;

/// <summary>
/// A thread-safe cached <see cref="HttpClient"/> configured for a SABnzbd instance.
/// </summary>
public interface ISabnzbdOpenApiHttpClient : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the configured HTTP client used by the Sabnzbd OpenAPI HTTP Client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested HTTP client.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
