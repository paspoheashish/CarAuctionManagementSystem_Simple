using AuthService.Application.DTOs;
using AuthService.Application.Interfaces;
using AuthService.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        
        private readonly IJwtTokenService _jwt;
        private readonly IAuthorizationService _authorizationService;

        public AuthController(IAuthorizationService authorizationService, IJwtTokenService jwt)
        {
            _authorizationService = authorizationService;
            _jwt = jwt;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _authorizationService.Authorize(request.Email, request.Password);

            if (user == null)
                return Unauthorized(new { message = "Invalid credentials" });

            var token = _jwt.GenerateToken(user);

            return Ok(new LoginResponse
            {
                Token = token,
                UserId = user.UserId,
                Email = user.Email,
                Role = user.Role
            });
        }
    }
}

