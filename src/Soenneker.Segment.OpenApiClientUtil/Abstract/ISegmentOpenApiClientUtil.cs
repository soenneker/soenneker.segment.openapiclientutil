using Soenneker.Segment.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Segment.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a lazily created, cached Segment OpenAPI client.
/// </summary>
public interface ISegmentOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the authenticated Segment OpenAPI client for this utility instance.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The cached generated client.</returns>
    ValueTask<SegmentOpenApiClient> Get(CancellationToken cancellationToken = default);
}
