using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace NotificationService.Controllers
{
    public class NotificationController : Controller
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
