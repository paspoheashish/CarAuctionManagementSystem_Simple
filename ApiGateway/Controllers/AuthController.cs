using AuctionService.Infrastructure.Clients;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [ApiController]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        //private readonly AuthnClient _client;

        //public AuthController(AuthnClient client)
        //{
        //    _client = client;
        //}

        //[HttpPost("login")]
        //public async Task<IActionResult> Login(LoginRequest request)
        //{
        //    var response = await _client.Login(request);

        //    var content = await response.Content.ReadAsStringAsync();

        //    return StatusCode((int)response.StatusCode, content);
        //}
    }
}
