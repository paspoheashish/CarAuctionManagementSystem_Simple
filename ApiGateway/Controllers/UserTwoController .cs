using ApiGateway.Application.Interfaces;
using Asp.Versioning;
using AuctionService.Infrastructure.Clients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.DTOs;

namespace ApiGateway.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/Users")]
    [ApiVersion("2.0")]
    public class UserTwoController : Controller
    {
        private readonly IUserClient _client;

        public UserTwoController(IUserClient client)
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

        [AllowAnonymous]
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
