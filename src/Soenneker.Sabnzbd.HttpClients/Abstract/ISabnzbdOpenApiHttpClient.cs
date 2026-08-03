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
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
