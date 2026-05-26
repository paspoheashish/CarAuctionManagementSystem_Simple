using Microsoft.AspNetCore.Mvc;
using UserService.Application.DTOs;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly Application.Services.UserService _service;

        public UsersController(Application.Services.UserService service)
        {
            _service = service;
        }

        [HttpGet("user/{email}")]
        public async Task<IActionResult> GetUser(string email)
        {
            var user = await _service.GetByEmailAsync(email);

            if (user == null) 
                return NotFound(new { message = "User not found." });

            return Ok(new { user.Id, user.Email, user.FirstName, user.LastName });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserDto dto)
        {
            if(await _service.GetByEmailAsync(dto.Email) != null)
            {
                 return Conflict(new { message = "Email already exists." });
            }

            var user = await _service.CreateUserAsync(dto);
            return Ok(new { user.Id, user.Email, user.FirstName, user.LastName });
        }

        [HttpPost("validate")]
        public async Task<IActionResult> Validate(ValidateCredentialsDto dto)
        {
            var user = await _service.ValidateAsync(dto.Email, dto.Password);

            if (user == null) 
                return Unauthorized(new { message = "Invalid User."});

            return Ok(new {userId = user.Id, email = user.Email, user.FirstName, user.LastName, role = user.Role });
        }
    }

}
