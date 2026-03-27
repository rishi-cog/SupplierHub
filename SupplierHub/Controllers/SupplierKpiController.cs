using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplierHub.DTOs.SupplierKpiDTO;
using SupplierHub.Services.Interface;

namespace SupplierHub.Controllers
{
    [Authorize(Roles = "Supplier,Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierKpiController : ControllerBase
    {
        private readonly ISupplierKpiService _service;

        public SupplierKpiController(ISupplierKpiService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SupplierKpiCreateDto dto)
        {
            try
            {
                var created = await _service.CreateKpiAsync(dto);
                return Ok(new { message = "Supplier KPI created successfully.", data = created });
            }
            catch (InvalidOperationException ex) { return Conflict(new { message = ex.Message }); }
            catch (Exception ex) { return StatusCode(500, new { message = "An error occurred.", error = ex.Message }); }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var kpis = await _service.GetAllKpisAsync();
                return Ok(new { message = "Supplier KPIs retrieved successfully.", data = kpis });
            }
            catch (Exception ex) { return StatusCode(500, new { message = "An error occurred.", error = ex.Message }); }
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var result = await _service.GetKpiByIdAsync(id);
                if (result == null) return NotFound(new { message = $"KPI with ID {id} not found." });
                return Ok(new { message = "Supplier KPI retrieved successfully.", data = result });
            }
            catch (Exception ex) { return StatusCode(500, new { message = "An error occurred.", error = ex.Message }); }
        }

        [HttpGet("supplier/{supplierId:long}")]
        public async Task<IActionResult> GetBySupplier(long supplierId)
        {
            try
            {
                var results = await _service.GetKpisBySupplierAsync(supplierId);
                return Ok(new { message = $"KPIs for Supplier {supplierId} retrieved.", data = results });
            }
            catch (Exception ex) { return StatusCode(500, new { message = "An error occurred.", error = ex.Message }); }
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] SupplierKpiUpdateDto dto)
        {
            try
            {
                var updated = await _service.UpdateKpiAsync(id, dto);
                if (updated == null) return NotFound(new { message = $"KPI with ID {id} not found." });
                return Ok(new { message = "Supplier KPI updated successfully.", data = updated });
            }
            catch (InvalidOperationException ex) { return Conflict(new { message = ex.Message }); }
            catch (Exception ex) { return StatusCode(500, new { message = "An error occurred.", error = ex.Message }); }
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var success = await _service.DeleteKpiAsync(id);
                if (!success) return NotFound(new { message = $"No matching KPI found with ID {id}." });
                return Ok(new { message = "Supplier KPI deleted successfully." });
            }
            catch (Exception ex) { return StatusCode(500, new { message = "An error occurred.", error = ex.Message }); }
        }
    }
}