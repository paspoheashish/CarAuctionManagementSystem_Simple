using ApiGateway.Application.Interfaces;
using Asp.Versioning;
using AuctionService.Infrastructure.Clients;
using AuthService.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Auth")]
    [ApiVersion("1.0")]
    public class AuthController : Controller
    {
        private readonly IAuthClient _client;

        public AuthController(IAuthClient client)
        {
            _client = client;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var response = await _client.Login(request);

            var content = await response.Content.ReadAsStringAsync();

            return StatusCode((int)response.StatusCode, content);
        }
    }
}
