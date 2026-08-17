using Soenneker.Segment.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Segment.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class SegmentOpenApiClientUtilTests : HostedUnitTest
{
    private readonly ISegmentOpenApiClientUtil _openapiclientutil;

    public SegmentOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<ISegmentOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
