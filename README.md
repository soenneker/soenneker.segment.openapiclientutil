[![](https://img.shields.io/nuget/v/soenneker.segment.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.segment.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.segment.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.segment.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.segment.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.segment.openapiclientutil/)

# Soenneker.Segment.OpenApiClientUtil

Exposes a cached OpenAPI client instance.

## Install

```bash
dotnet add package Soenneker.Segment.OpenApiClientUtil
```

## Quick start

```csharp
using Soenneker.Segment.OpenApiClientUtil.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddSegmentOpenApiClientUtilAsSingleton();
```

Adds `SegmentOpenApiClientUtil` as a singleton service.

## What you get

- `ISegmentOpenApiClientUtil` — Exposes a cached OpenAPI client instance.
- `SegmentOpenApiClientUtilRegistrar` — Registers the OpenAPI client utility for dependency injection.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `SegmentOpenApiClientUtilRegistrar.AddSegmentOpenApiClientUtilAsSingleton(services)` | Adds `SegmentOpenApiClientUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `SegmentOpenApiClientUtilRegistrar.AddSegmentOpenApiClientUtilAsScoped(services)` | Adds `SegmentOpenApiClientUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Dispose instances you own when their scope ends so held resources can be released.
