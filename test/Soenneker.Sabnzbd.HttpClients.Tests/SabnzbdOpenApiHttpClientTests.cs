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
    public void Default()
    {

    }
}
