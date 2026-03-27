using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SupplierHub.DTOs.UserRoleDTO;
using SupplierHub.Services.Interface;

namespace SupplierHub.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserRoleController : ControllerBase
	{
		private readonly IUserRoleService _service;
		private readonly ILogger<UserRoleController> _logger;

		public UserRoleController(IUserRoleService service, ILogger<UserRoleController> logger)
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
				_logger.LogError(ex, "Error fetching all user-role assignments.");
				return StatusCode(500, new { message = "An error occurred while retrieving user-role data." });
			}
		}

		[HttpGet("user/{userId:long}")]
		public async Task<IActionResult> GetByUser(long userId, [FromQuery] bool includeDeleted = false, CancellationToken ct = default)
		{
			try
			{
				var items = await _service.GetByUserAsync(userId, includeDeleted, ct);
				return Ok(items);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error fetching roles for User ID {UserId}", userId);
				return StatusCode(500, new { message = $"Could not retrieve roles for User ID {userId}." });
			}
		}

		[HttpGet("{userId:long}/{roleId:long}")]
		public async Task<IActionResult> GetByIds(long userId, long roleId, CancellationToken ct = default)
		{
			try
			{
				var item = await _service.GetByIdsAsync(userId, roleId, ct);
				if (item == null)
					return NotFound(new { message = $"No assignment found for User {userId} and Role {roleId}." });

				return Ok(item);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error fetching user-role mapping {UserId}-{RoleId}", userId, roleId);
				return StatusCode(500, new { message = "An internal error occurred while fetching this specific role assignment." });
			}
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateUserRoleDto dto, CancellationToken ct = default)
		{
			if (!ModelState.IsValid)
				return BadRequest(new { message = "Invalid data provided for role assignment.", errors = ModelState });

			try
			{
				var created = await _service.CreateAsync(dto, ct);
				return Ok(new { message = "Role assigned to user successfully.", data = created });
			}
			// 1. Catch business logic exceptions thrown manually from your Service
			catch (InvalidOperationException ex)
			{
				_logger.LogWarning("Duplicate assignment attempt: {Message}", ex.Message);
				return Conflict(new { message = "This user already has the specified role assigned." });
			}
			// 2. Catch Database errors (Unique Constraint violations)
			catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
			{
				_logger.LogWarning(ex, "Database update error during user-role assignment.");

				// If the inner exception mentions 'duplicate' or 'unique index', it's a duplicate
				if (ex.InnerException?.Message.Contains("duplicate", StringComparison.OrdinalIgnoreCase) == true ||
					ex.InnerException?.Message.Contains("unique", StringComparison.OrdinalIgnoreCase) == true)
				{
					return Conflict(new { message = "Conflict: This user-role assignment already exists." });
				}

				return BadRequest(new { message = "Failed to assign role. Please ensure the User and Role IDs are valid." });
			}
			// 3. Catch everything else
			catch (Exception ex)
			{
				_logger.LogError(ex, "Unexpected error creating user-role");
				return StatusCode(500, new { message = "An internal server error occurred while assigning the role." });
			}
		}

		[HttpPut("{userId:long}/{roleId:long}")]
		public async Task<IActionResult> Update(long userId, long roleId, [FromBody] UpdateUserRoleDto dto, CancellationToken ct = default)
		{
			if (!ModelState.IsValid)
				return BadRequest(new { message = "Validation failed for role-assignment update.", errors = ModelState });

			try
			{
				var updated = await _service.UpdateAsync(userId, roleId, dto, ct);
				if (updated == null)
					return NotFound(new { message = $"Update failed: Assignment for User {userId} and Role {roleId} was not found." });

				return Ok(new { message = "User-role assignment updated successfully.", data = updated });
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error updating user-role {UserId}-{RoleId}", userId, roleId);
				return StatusCode(500, new { message = "An unexpected error occurred during the update." });
			}
		}

		[HttpDelete("{userId:long}/{roleId:long}")]
		public async Task<IActionResult> Delete(long userId, long roleId, CancellationToken ct = default)
		{
			try
			{
				var ok = await _service.SoftDeleteAsync(userId, roleId, ct);
				if (!ok)
					return NotFound(new { message = $"Delete failed: No active assignment found for User {userId} and Role {roleId}." });

				return Ok(new { message = "Role has been successfully removed from the user." });
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error deleting user-role {UserId}-{RoleId}", userId, roleId);
				return StatusCode(500, new { message = "An error occurred while trying to remove the role assignment." });
			}
		}
	}
}