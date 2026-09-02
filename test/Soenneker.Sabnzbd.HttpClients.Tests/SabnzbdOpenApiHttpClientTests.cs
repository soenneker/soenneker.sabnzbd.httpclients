using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Sabnzbd.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Sabnzbd.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class SabnzbdOpenApiHttpClientTests : HostedUnitTest
{
    private readonly ISabnzbdOpenApiHttpClient _httpclient;

    public SabnzbdOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<ISabnzbdOpenApiHttpClient>(true);
    }

    [Test]
    public async Task Get_uses_configured_sabnzbd_base_url(CancellationToken cancellationToken)
    {
        HttpClient client = await _httpclient.Get(cancellationToken: cancellationToken);

        await Assert.That(client.BaseAddress).IsEqualTo(new Uri("http://localhost:18080"));
        await Assert.That(client.DefaultRequestHeaders.Authorization).IsNull();
    }
}
