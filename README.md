[![](https://img.shields.io/nuget/v/soenneker.segment.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.segment.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.segment.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.segment.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.segment.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.segment.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.segment.openapiclientutil/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.segment.openapiclientutil/actions/workflows/codeql.yml)

# Soenneker.Segment.OpenApiClientUtil

A DI-ready, lazily cached Segment Public API client.

## Installation

```bash
dotnet add package Soenneker.Segment.OpenApiClientUtil
```

## Configuration

```json
{
  "Segment": {
    "ApiToken": "your-segment-token"
  }
}
```

The default endpoint is `https://api.segmentapis.com` with `Authorization: Bearer {token}` authentication. The same optional `ClientBaseUrl`, `AuthHeaderName`, and `AuthHeaderValueTemplate` settings supported by `Soenneker.Segment.HttpClients` are honored.

## Registration

```csharp
using Soenneker.Segment.OpenApiClientUtil.Registrars;

services.AddSegmentOpenApiClientUtilAsSingleton();
```

Use the scoped registration for a scoped consumer:

```csharp
services.AddSegmentOpenApiClientUtilAsScoped();
```

The scoped utility deliberately uses a singleton HTTP client provider and transport. Disposing a scope discards that utility's generated-client cache while leaving the underlying shared `HttpClient` alive.

## Usage

```csharp
using Soenneker.Segment.OpenApiClient;
using Soenneker.Segment.OpenApiClient.Models;
using Soenneker.Segment.OpenApiClientUtil.Abstract;

public sealed class SegmentSourceReader(ISegmentOpenApiClientUtil clientUtil)
{
    public async Task<ListSources200SegmentV1JsonResponse?> GetSources(
        CancellationToken cancellationToken)
    {
        SegmentOpenApiClient client = await clientUtil.Get(cancellationToken);
        return await client.Sources.GetAsync(cancellationToken: cancellationToken);
    }
}
```

The generated client is created on the first `Get` call and reused for the lifetime of the utility. Endpoint and authentication configuration are captured at creation; recreate the utility and its cached transport when rotating them at runtime.

Authentication is attached to requests created by the generated client and is also configured on the underlying HTTP client. Do not use `WithUrl` or the returned transport to send absolute URLs outside the configured Segment authority, because doing so can forward the configured authentication header to that host.
