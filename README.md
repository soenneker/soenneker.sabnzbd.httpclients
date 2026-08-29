[![](https://img.shields.io/nuget/v/soenneker.sabnzbd.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.sabnzbd.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.sabnzbd.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.sabnzbd.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.sabnzbd.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.sabnzbd.httpclients/)

# Soenneker.Sabnzbd.HttpClients

A thread-safe cached `HttpClient` configured for a SABnzbd instance.

## Install

```bash
dotnet add package Soenneker.Sabnzbd.HttpClients
```

## Quick start

```csharp
using Soenneker.Sabnzbd.HttpClients.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddSabnzbdOpenApiHttpClientAsSingleton();
```

Adds `SabnzbdOpenApiHttpClient` as a singleton service.

## What you get

- `ISabnzbdOpenApiHttpClient` — A thread-safe cached `HttpClient` configured for a SABnzbd instance.
- `SabnzbdOpenApiHttpClientRegistrar` — Registers the OpenAPI HttpClient wrapper for dependency injection.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `SabnzbdOpenApiHttpClientRegistrar.AddSabnzbdOpenApiHttpClientAsSingleton(services)` | Adds `SabnzbdOpenApiHttpClient` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `SabnzbdOpenApiHttpClientRegistrar.AddSabnzbdOpenApiHttpClientAsScoped(services)` | Adds `SabnzbdOpenApiHttpClient` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Dispose instances you own when their scope ends so held resources can be released.
