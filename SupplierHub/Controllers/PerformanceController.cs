using Microsoft.AspNetCore.Mvc;
using SupplierHub.DTOs.SupplierKpiDTO; // Adjust namespace based on your folder structure
using SupplierHub.Services.Interface;
using SupplierHub.DTOs.ScorecardDTO; 

namespace SupplierHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PerformanceController : ControllerBase
    {
        private readonly IPerformanceService _service;

        public PerformanceController(IPerformanceService service)
        {
            _service = service;
        }

        // --- KPIs ---
        [HttpPost("kpi")]
        public async Task<IActionResult> LogKpi(SupplierKpiCreateDto dto) =>
            Ok(await _service.CreateKpiAsync(dto));

        // --- Scorecards ---
        [HttpGet("scorecard/{supplierId:long}")]
        public async Task<IActionResult> GetScorecards(long supplierId)
        {
            var result = await _service.GetScorecardsBySupplierAsync(supplierId);
            return Ok(result);
        }

        [HttpPost("scorecard")]
        public async Task<IActionResult> CreateScorecard(ScorecardCreateDto dto)
        {
            var result = await _service.CreateScorecardAsync(dto);
            return Ok(result);
        }
    }
}