using AuctionService.Infrastructure.Clients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.DTOs;
using static System.Net.Mime.MediaTypeNames;

namespace ApiGateway.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Users")]
    public class UserController : Controller
    {
        private readonly UserClient _client;

        public UserController(UserClient client)
        {
            _client = client;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetUser(string email)
        {
            var response = await _client.GetUser(email);

            var content = await response.Content.ReadAsStringAsync();

            return StatusCode((int)response.StatusCode, content);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserDto dto)
        {
            var response = await _client.Register(dto);

            var content = await response.Content.ReadAsStringAsync();

            return StatusCode((int)response.StatusCode, content);
        }

        [HttpPost("validate")]
        public async Task<IActionResult> Validate(ValidateCredentialsDto dto)
        {
            var response = await _client.Validate(dto);

            var content = await response.Content.ReadAsStringAsync();

            return StatusCode((int)response.StatusCode, content);
        }
    }
}
