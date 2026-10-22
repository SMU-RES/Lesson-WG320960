using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using taskweb.Services;

namespace taskweb.Controllers;

// 采样数据 API：供仪表盘页面轮询/刷新。
[Authorize]
[ApiController]
[Route("api/telemetry")]
public sealed class TelemetryApiController : ControllerBase
{
    private readonly TelemetryQueryService _svc;

    public TelemetryApiController(TelemetryQueryService svc)
    {
        _svc = svc;
    }

    [HttpGet("latest")]
    public async Task<IReadOnlyList<TelemetrySampleDto>> Latest([FromQuery] int limit = 500, CancellationToken ct = default)
    {
        // limit 会在服务内部做裁剪。
        return await _svc.GetLatestSamplesAsync(limit, ct);
    }
}
