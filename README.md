[![](https://img.shields.io/nuget/v/soenneker.sabnzbd.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.sabnzbd.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.sabnzbd.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.sabnzbd.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.sabnzbd.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.sabnzbd.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.sabnzbd.httpclients/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.sabnzbd.httpclients/actions/workflows/codeql.yml)

# Soenneker.Sabnzbd.HttpClients

A cached `HttpClient` provider configured with a SABnzbd server's base URL.

## Installation

```bash
dotnet add package Soenneker.Sabnzbd.HttpClients
```

## Configuration

```json
{
  "Sabnzbd": {
    "ClientBaseUrl": "http://localhost:8080"
  }
}
```

`Sabnzbd:ClientBaseUrl` must be an absolute URI. When omitted, the client uses `http://localhost:8080`.

## Registration

```csharp
using Soenneker.Sabnzbd.HttpClients.Registrars;

services.AddSabnzbdOpenApiHttpClientAsSingleton();
```

Scoped registration is also available when the consuming service is scoped:

```csharp
services.AddSabnzbdOpenApiHttpClientAsScoped();
```

Both registrations keep the underlying cached `HttpClient` singleton. Disposing a scoped provider releases only that wrapper; it does not remove the shared transport.

## Usage

```csharp
using Soenneker.Sabnzbd.HttpClients.Abstract;

public sealed class SabnzbdStatusClient(ISabnzbdOpenApiHttpClient clientProvider)
{
    public async Task<string> GetVersion(CancellationToken cancellationToken)
    {
        HttpClient client = await clientProvider.Get(cancellationToken);

        return await client.GetStringAsync(
            "/api?mode=version&output=json&apikey=YOUR_API_KEY",
            cancellationToken);
    }
}
```

The provider configures only `HttpClient.BaseAddress`; it does not attach an API key or other authentication. Add the SABnzbd API key through the generated client or request parameters appropriate to your application. Repeated calls to `Get` return the cached client rather than creating a transport per request.
