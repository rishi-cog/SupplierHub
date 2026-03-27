using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SupplierHub.DTOs.UserDTO;
using SupplierHub.Services.Interface;

namespace SupplierHub.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[AllowAnonymous]
	public class UserController : ControllerBase
	{
		private readonly IUserService _service;
		private readonly ILogger<UserController> _logger;

		public UserController(IUserService service, ILogger<UserController> logger)
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
				_logger.LogError(ex, "Error fetching all users.");
				return StatusCode(500, new { message = "An error occurred while retrieving the user list." });
			}
		}

		[HttpGet("{id:long}")]
		public async Task<IActionResult> GetById(long id, CancellationToken ct = default)
		{
			try
			{
				var item = await _service.GetByIdAsync(id, ct);
				if (item == null)
					return NotFound(new { message = $"User with ID {id} was not found." });

				return Ok(item);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error retrieving user {UserId}", id);
				return StatusCode(500, new { message = $"An internal error occurred while fetching user details for ID {id}." });
			}
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Create([FromBody] CreateUserDto dto, CancellationToken ct = default)
		{
			if (!ModelState.IsValid)
				return BadRequest(new { message = "Registration data is invalid.", errors = ModelState });

			try
			{
				var created = await _service.CreateAsync(dto, ct);
				return CreatedAtAction(nameof(GetById), new { id = created.UserID }, new { message = "User account created successfully.", data = created });
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error creating user");

				// Handling specific business logic errors from the service
				if (ex.Message.Contains("Email", StringComparison.OrdinalIgnoreCase))
				{
					return Conflict(new { message = "This email address is already registered." });
				}

				return StatusCode(500, new { message = "An unexpected error occurred during user registration." });
			}
		}

		[HttpPut("{id:long}")]
		public async Task<IActionResult> Update(long id, [FromBody] UpdateUserDto dto, CancellationToken ct = default)
		{
			if (!ModelState.IsValid)
				return BadRequest(new { message = "Validation failed for the update request.", errors = ModelState });

			try
			{
				var updated = await _service.UpdateAsync(id, dto, ct);
				if (updated == null)
					return NotFound(new { message = $"Update failed: User with ID {id} does not exist." });

				return Ok(new { message = "User profile updated successfully.", data = updated });
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error updating user {UserId}", id);
				return StatusCode(500, new { message = "An error occurred while updating the user profile." });
			}
		}

		[HttpDelete("{id:long}")]
		public async Task<IActionResult> Delete(long id, CancellationToken ct = default)
		{
			try
			{
				var ok = await _service.SoftDeleteAsync(id, ct);
				if (!ok)
					return NotFound(new { message = $"Delete failed: No user found with ID {id}." });

				return Ok(new { message = "User account has been successfully deactivated." });
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error deleting user {UserId}", id);
				return StatusCode(500, new { message = "The system encountered an error while trying to delete the user account." });
			}
		}
	}
}