using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SupplierHub.DTOs.PermissionDTO;
using SupplierHub.Services.Interface;

namespace SupplierHub.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PermissionController : ControllerBase
	{
		private readonly IPermissionService _service;
		private readonly ILogger<PermissionController> _logger;

		public PermissionController(IPermissionService service, ILogger<PermissionController> logger)
		{
			_service = service;
			_logger = logger;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery] bool includeDeleted = false, CancellationToken ct = default)
		{
			try
			{
				var items = await _service.GetAllAsync(includeDeleted, ct);

				if (items == null)
					return Ok(new { message = "No permissions found in the system.", data = Array.Empty<object>() });

				return Ok(items);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error fetching all permissions.");
				return StatusCode(500, new { message = "An error occurred while retrieving the permission list. Please try again later." });
			}
		}

		[HttpGet("{id:long}")]
		public async Task<IActionResult> GetById(long id, CancellationToken ct = default)
		{
			try
			{
				var item = await _service.GetByIdAsync(id, ct);
				if (item == null)
					return NotFound(new { message = $"Permission record with ID {id} was not found." });

				return Ok(item);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error retrieving permission {Id}", id);
				return StatusCode(500, new { message = $"An internal error occurred while fetching permission ID {id}." });
			}
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreatePermissionDto dto, CancellationToken ct = default)
		{
			if (!ModelState.IsValid)
				return BadRequest(new { message = "Invalid data provided.", errors = ModelState });

			try
			{
				var created = await _service.CreateAsync(dto, ct);
				return CreatedAtAction(nameof(GetById), new { id = created.PermissionID }, new { message = "Permission created successfully.", data = created });
			}
			// 1. Catch database-level unique constraint violations
			catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
			{
				_logger.LogWarning(ex, "Database update error during permission creation.");

				// Check if the internal SQL error mentions a duplicate key
				if (ex.InnerException?.Message.Contains("duplicate", StringComparison.OrdinalIgnoreCase) == true)
				{
					return Conflict(new { message = $"Conflict: A permission with the code '{dto.Code}' already exists." });
				}

				return BadRequest(new { message = "A database error occurred while saving the permission." });
			}
			// 2. Catch business logic errors from your Service
			catch (InvalidOperationException ex)
			{
				_logger.LogWarning("Duplicate permission attempt: {Message}", ex.Message);
				return Conflict(new { message = "Creation failed: This permission name or code is already in use." });
			}
			// 3. Catch all other unexpected errors
			catch (Exception ex)
			{
				_logger.LogError(ex, "Unexpected error during permission creation.");
				return StatusCode(500, new { message = "We encountered a problem creating the permission. Please contact support." });
			}
		}

		[HttpPut("{id:long}")]
		public async Task<IActionResult> Update(long id, [FromBody] UpdatePermissionDto dto, CancellationToken ct = default)
		{
			if (!ModelState.IsValid)
				return BadRequest(new { message = "Validation failed for the update request.", errors = ModelState });

			try
			{
				var updated = await _service.UpdateAsync(id, dto, ct);
				if (updated == null)
					return NotFound(new { message = $"Update failed: Permission with ID {id} does not exist." });

				return Ok(new { message = "Permission updated successfully.", data = updated });
			}
			catch (InvalidOperationException ex)
			{
				return Conflict(new { message = "Update failed: The changes conflict with an existing permission." });
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error updating permission {Id}", id);
				return StatusCode(500, new { message = "An unexpected error occurred while updating the permission." });
			}
		}

		[HttpDelete("{id:long}")]
		public async Task<IActionResult> Delete(long id, CancellationToken ct = default)
		{
			try
			{
				var success = await _service.SoftDeleteAsync(id, ct);
				if (!success)
					return NotFound(new { message = $"Delete failed: No permission found with ID {id}." });

				return Ok(new { message = $"Permission {id} has been deleted successfully." });
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error deleting permission {Id}", id);
				return StatusCode(500, new { message = "The system could not complete the deletion. Please try again." });
			}
		}
	}
}
