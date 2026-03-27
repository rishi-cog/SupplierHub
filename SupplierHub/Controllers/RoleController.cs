using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SupplierHub.DTOs.RoleDTO;
using SupplierHub.Services.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SupplierHub.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[Authorize(Roles = "Admin")]
	public class RoleController : ControllerBase
	{
		private readonly IRoleService _service;
		private readonly ILogger<RoleController> _logger;

		public RoleController(IRoleService service, ILogger<RoleController> logger)
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
				_logger.LogError(ex, "Error fetching all roles.");
				return StatusCode(500, new { message = "An error occurred while retrieving the list of roles." });
			}
		}

		[HttpGet("{id:long}")]
		public async Task<IActionResult> GetById(long id, CancellationToken ct = default)
		{
			try
			{
				var item = await _service.GetByIdAsync(id, ct);
				if (item == null)
					return NotFound(new { message = $"Role with ID {id} was not found." });

				return Ok(item);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error retrieving role {RoleId}", id);
				return StatusCode(500, new { message = $"An error occurred while fetching role details for ID {id}." });
			}
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateRoleDto dto, CancellationToken ct = default)
		{
			if (!ModelState.IsValid)
				return BadRequest(new { message = "Invalid role data provided.", errors = ModelState });

			try
			{
				var created = await _service.CreateAsync(dto, ct);
				return CreatedAtAction(nameof(GetById), new { id = created.RoleID }, new { message = "Role created successfully.", data = created });
			}
			catch (InvalidOperationException ex)
			{
				_logger.LogWarning("Duplicate role creation attempt: {Message}", ex.Message);
				return Conflict(new { message = "Creation failed: A role with this name already exists." });
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Unexpected error creating role.");
				return StatusCode(500, new { message = "An error occurred while creating the new role. Please try again." });
			}
		}

		[HttpPut("{id:long}")]
		public async Task<IActionResult> Update(long id, [FromBody] UpdateRoleDto dto, CancellationToken ct = default)
		{
			if (!ModelState.IsValid)
				return BadRequest(new { message = "Validation failed for the role update.", errors = ModelState });

			try
			{
				var updated = await _service.UpdateAsync(id, dto, ct);
				if (updated == null)
					return NotFound(new { message = $"Update failed: Role with ID {id} does not exist." });

				return Ok(new { message = "Role updated successfully.", data = updated });
			}
			catch (InvalidOperationException ex)
			{
				return Conflict(new { message = "Update failed: The role name you are trying to use is already taken." });
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error updating role {RoleId}", id);
				return StatusCode(500, new { message = "An unexpected error occurred while updating the role." });
			}
		}

		[HttpDelete("{id:long}")]
		public async Task<IActionResult> Delete(long id, CancellationToken ct = default)
		{
			try
			{
				var ok = await _service.SoftDeleteAsync(id, ct);
				if (!ok)
					return NotFound(new { message = $"Delete failed: No role found with ID {id}." });

				return Ok(new { message = $"Role {id} has been successfully deleted (soft-delete)." });
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error deleting role {RoleId}", id);
				return StatusCode(500, new { message = "The system encountered an error while trying to delete the role." });
			}
		}
	}
}