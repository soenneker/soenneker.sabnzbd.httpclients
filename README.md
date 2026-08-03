[![](https://img.shields.io/nuget/v/soenneker.sabnzbd.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.sabnzbd.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.sabnzbd.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.sabnzbd.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.sabnzbd.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.sabnzbd.httpclients/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Sabnzbd.HttpClients
### A thread-safe singleton HttpClient for SABnzbd's OpenAPI integration.

## Installation

```
dotnet add package Soenneker.Sabnzbd.HttpClients
```

## Configuration

Configure `Sabnzbd:ClientBaseUrl` with the root URL of the SABnzbd instance. Do not append `/api`; the generated OpenAPI client adds that path.

```json
{
  "Sabnzbd": {
    "ClientBaseUrl": "http://localhost:8080"
  }
}
```

SABnzbd authenticates API requests with the `apikey` query parameter. The API key should be added by the Kiota authentication provider and is intentionally not configured as an HTTP authorization header by this package.
