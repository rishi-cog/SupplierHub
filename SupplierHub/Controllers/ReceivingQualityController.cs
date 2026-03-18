using Microsoft.AspNetCore.Mvc;
using SupplierHub.DTOs.GrnRefDTO; // Adjust namespace based on your folder structure
using SupplierHub.Services.Interface;
using SupplierHub.DTOs.InspectionDTO;
using SupplierHub.DTOs.NcrDTO;
using SupplierHub.DTOs.GrnItemRefDTO;

namespace SupplierHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceivingQualityController : ControllerBase
    {
        private readonly IReceivingQualityService _service;

        public ReceivingQualityController(IReceivingQualityService service)
        {
            _service = service;
        }

        // --- GRN & Items ---
        [HttpGet("grn/{id:long}")]
        public async Task<IActionResult> GetGrn(long id)
        {
            var result = await _service.GetGrnByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost("grn")]
        public async Task<IActionResult> CreateGrn([FromBody] GrnCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await _service.CreateGrnAsync(dto);
                return CreatedAtAction(nameof(GetGrn), new { id = created.GrnID }, created);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // --- Inspections ---
        [HttpPost("inspections")]
        public async Task<IActionResult> CreateInspection([FromBody] InspectionCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await _service.CreateInspectionAsync(dto);
                return Ok(created);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // --- NCR (Non-Conformance) ---
        [HttpPost("ncr")]
        public async Task<IActionResult> CreateNcr([FromBody] NcrCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await _service.CreateNcrAsync(dto);
                return Ok(created);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("ncr/item/{grnItemId:long}")]
        public async Task<IActionResult> GetNcrsByItem(long grnItemId)
        {
            var result = await _service.GetNcrsByItemIdAsync(grnItemId);
            return Ok(result);
        }
    }
}