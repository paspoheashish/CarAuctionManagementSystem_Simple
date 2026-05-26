using AuctionService.Infrastructure.Clients;
using AuthService.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [ApiController]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private readonly AuthClient _client;

        public AuthController(AuthClient client)
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
