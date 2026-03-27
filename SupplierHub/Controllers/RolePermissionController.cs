using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SupplierHub.DTOs.RolePermissionDTO;
using SupplierHub.Services.Interface;

namespace SupplierHub.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RolePermissionController : ControllerBase
	{
		private readonly IRolePermissionService _service;
		private readonly ILogger<RolePermissionController> _logger;

		public RolePermissionController(IRolePermissionService service, ILogger<RolePermissionController> logger)
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
				return Ok(items);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error fetching all role-permission mappings.");
				return StatusCode(500, new { message = "An error occurred while retrieving role-permission data." });
			}
		}

		[HttpGet("role/{roleId:long}")]
		public async Task<IActionResult> GetByRole(long roleId, [FromQuery] bool includeDeleted = false, CancellationToken ct = default)
		{
			try
			{
				var items = await _service.GetByRoleAsync(roleId, includeDeleted, ct);
				return Ok(items);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error fetching permissions for Role ID {RoleId}", roleId);
				return StatusCode(500, new { message = $"Could not retrieve permissions for Role ID {roleId}." });
			}
		}

		[HttpGet("{roleId:long}/{permissionId:long}")]
		public async Task<IActionResult> GetByIds(long roleId, long permissionId, CancellationToken ct = default)
		{
			try
			{
				var item = await _service.GetByIdsAsync(roleId, permissionId, ct);
				if (item == null)
					return NotFound(new { message = $"No mapping found for Role ID {roleId} and Permission ID {permissionId}." });

				return Ok(item);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error fetching role-permission mapping {RoleId}-{PermissionId}", roleId, permissionId);
				return StatusCode(500, new { message = "An error occurred while fetching the specific permission mapping." });
			}
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateRolePermissionDto dto, CancellationToken ct = default)
		{
			if (!ModelState.IsValid)
				return BadRequest(new { message = "Invalid data provided for role-permission assignment.", errors = ModelState });

			try
			{
				var created = await _service.CreateAsync(dto, ct);
				return Ok(new { message = "Permission successfully assigned to the role.", data = created });
			}
			// 1. Catch specific business logic exceptions thrown by the service
			catch (InvalidOperationException ex)
			{
				_logger.LogWarning("Assignment conflict: {Message}", ex.Message);
				return Conflict(new { message = "Conflict: This role already has this permission assigned." });
			}
			// 2. Catch Database uniqueness violations (e.g., Primary Key or Unique Constraint)
			catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
			{
				_logger.LogWarning(ex, "Database error during role-permission assignment.");

				// Check if the inner exception mentions a duplicate key or unique constraint
				if (ex.InnerException?.Message.Contains("duplicate", StringComparison.OrdinalIgnoreCase) == true ||
					ex.InnerException?.Message.Contains("unique", StringComparison.OrdinalIgnoreCase) == true)
				{
					return Conflict(new { message = "This role-permission mapping already exists in the system." });
				}

				return BadRequest(new { message = "Failed to assign permission. Please ensure Role and Permission IDs are valid." });
			}
			// 3. Catch all other unexpected errors
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error creating role-permission mapping");

				// Extra check: if the service threw a generic Exception with a "duplicate" message
				if (ex.Message.Contains("already exists", StringComparison.OrdinalIgnoreCase))
				{
					return Conflict(new { message = "This assignment already exists." });
				}

				return StatusCode(500, new { message = "An internal server error occurred while assigning the permission." });
			}
		}

		[HttpPut("{roleId:long}/{permissionId:long}")]
		public async Task<IActionResult> Update(long roleId, long permissionId, [FromBody] UpdateRolePermissionDto dto, CancellationToken ct = default)
		{
			if (!ModelState.IsValid)
				return BadRequest(new { message = "Validation failed for mapping update.", errors = ModelState });

			try
			{
				var updated = await _service.UpdateAsync(roleId, permissionId, dto, ct);
				if (updated == null)
					return NotFound(new { message = $"Update failed: Mapping for Role {roleId} and Permission {permissionId} does not exist." });

				return Ok(new { message = "Role-permission mapping updated successfully.", data = updated });
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error updating role-permission {RoleId}-{PermissionId}", roleId, permissionId);
				return StatusCode(500, new { message = "An internal error occurred while updating the mapping." });
			}
		}

		[HttpDelete("{roleId:long}/{permissionId:long}")]
		public async Task<IActionResult> Delete(long roleId, long permissionId, CancellationToken ct = default)
		{
			try
			{
				var ok = await _service.SoftDeleteAsync(roleId, permissionId, ct);
				if (!ok)
					return NotFound(new { message = $"Delete failed: Could not find mapping for Role {roleId} and Permission {permissionId}." });

				return Ok(new { message = "Permission removed from role successfully." });
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error deleting role-permission mapping {RoleId}-{PermissionId}", roleId, permissionId);
				return StatusCode(500, new { message = "An error occurred while trying to remove the permission from the role." });
			}
		}
	}
}