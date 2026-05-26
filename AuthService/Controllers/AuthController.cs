using AuthService.Application.DTOs;
using AuthService.Application.Services;
using AuthService.Infrastructure.Clients;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        
        private readonly JwtTokenService _jwt;
        private readonly AuthorizationService _authorizationService;

        public AuthController(AuthorizationService authorizationService, JwtTokenService jwt)
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

