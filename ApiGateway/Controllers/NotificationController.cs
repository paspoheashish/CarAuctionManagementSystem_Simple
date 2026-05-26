using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/notifications")]
    [ApiVersion("1.0")]
    public class NotificationController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AuctionStarted()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> BidPlaced()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AuctionClosed()
        {
            return Ok();
        }
    }
}
