using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
            var items = await _service.GetAllAsync(includeDeleted, ct);
            return Ok(items);
        }




        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id, CancellationToken ct = default)
        {
            var item = await _service.GetByIdAsync(id, ct);
            if (item == null)
                return NotFound();
            return Ok(item);
        }




		[HttpPost]
        [AllowAnonymous] // Allow anyone to create a user (e.g., for registration)
		public async Task<IActionResult> Create([FromBody] CreateUserDto dto, CancellationToken ct = default)
		{
			if (!ModelState.IsValid)
				return ValidationProblem(ModelState);

			try
			{
				var created = await _service.CreateAsync(dto, ct);
				return Ok(created);
			}
			catch (System.Exception ex)
			{
				_logger.LogError(ex, "Error creating user");

				// Check if the error message is the one we threw in the Service
				if (ex.Message == "Email is already registered.")
				{
					// This returns HTTP 409 Conflict instead of 500
					return Conflict(new { message = ex.Message });
				}

				// For any other unexpected error, return 500
				return Problem(ex.Message);
			}
		}






		[HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateUserDto dto, CancellationToken ct = default)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            try
            {
                var updated = await _service.UpdateAsync(id, dto, ct);
                if (updated == null)
                    return NotFound();
                return Ok(updated);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error updating user {UserId}", id);
                return Problem(ex.Message);
            }
        }





        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id, CancellationToken ct = default)
        {
            try
            {
                var ok = await _service.SoftDeleteAsync(id, ct);
                if (!ok) return NotFound();
                return Ok();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error deleting user {UserId}", id);
                return Problem(ex.Message);
            }
        }
    }
}