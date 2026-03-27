using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplierHub.DTOs.ScorecardDTO;
using SupplierHub.Services.Interface;

namespace SupplierHub.Controllers
{
    [Authorize(Roles = "Supplier,Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class ScorecardController : ControllerBase
    {
        private readonly IScorecardService _service;

        public ScorecardController(IScorecardService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ScorecardCreateDto dto)
        {
            try
            {
                var created = await _service.CreateScorecardAsync(dto);
                return Ok(new { message = "Scorecard created successfully.", data = created });
            }
            catch (InvalidOperationException ex) { return Conflict(new { message = ex.Message }); }
            catch (Exception ex) { return StatusCode(500, new { message = "An error occurred.", error = ex.Message }); }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var scorecards = await _service.GetAllScorecardsAsync();
                return Ok(new { message = "Scorecards retrieved successfully.", data = scorecards });
            }
            catch (Exception ex) { return StatusCode(500, new { message = "An error occurred.", error = ex.Message }); }
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var result = await _service.GetScorecardByIdAsync(id);
                if (result == null) return NotFound(new { message = $"Scorecard with ID {id} not found." });
                return Ok(new { message = "Scorecard retrieved successfully.", data = result });
            }
            catch (Exception ex) { return StatusCode(500, new { message = "An error occurred.", error = ex.Message }); }
        }

        [HttpGet("supplier/{supplierId:long}")]
        public async Task<IActionResult> GetBySupplier(long supplierId)
        {
            try
            {
                var results = await _service.GetScorecardsBySupplierAsync(supplierId);
                return Ok(new { message = $"Scorecards for Supplier {supplierId} retrieved.", data = results });
            }
            catch (Exception ex) { return StatusCode(500, new { message = "An error occurred.", error = ex.Message }); }
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] ScorecardUpdateDto dto)
        {
            try
            {
                var updated = await _service.UpdateScorecardAsync(id, dto);
                if (updated == null) return NotFound(new { message = $"Scorecard with ID {id} not found." });
                return Ok(new { message = "Scorecard updated successfully.", data = updated });
            }
            catch (InvalidOperationException ex) { return Conflict(new { message = ex.Message }); }
            catch (Exception ex) { return StatusCode(500, new { message = "An error occurred.", error = ex.Message }); }
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var success = await _service.DeleteScorecardAsync(id);
                if (!success) return NotFound(new { message = $"No matching Scorecard found with ID {id}." });
                return Ok(new { message = "Scorecard deleted successfully." });
            }
            catch (Exception ex) { return StatusCode(500, new { message = "An error occurred.", error = ex.Message }); }
        }
    }
}