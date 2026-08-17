using Soenneker.Segment.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Segment.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface ISegmentOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<SegmentOpenApiClient> Get(CancellationToken cancellationToken = default);
}
