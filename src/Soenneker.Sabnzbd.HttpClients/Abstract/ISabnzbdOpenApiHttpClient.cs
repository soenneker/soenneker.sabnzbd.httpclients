using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Sabnzbd.HttpClients.Abstract;

/// <summary>
/// Provides a cached <see cref="HttpClient"/> configured with a SABnzbd server base address.
/// </summary>
public interface ISabnzbdOpenApiHttpClient : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the shared HTTP client. Authentication is not added by this provider.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The cached HTTP client.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
