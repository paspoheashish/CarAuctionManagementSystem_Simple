using AuctionService.Application.DTOs;
using AuctionService.Infrastructure.Clients;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    public class AuctionController : Controller
    {
        private readonly AuctionClient _client;

        public AuctionController(AuctionClient client)
        {
            _client = client;
        }

        [HttpPost("start")]
        public async Task<IActionResult> Start(StartAuctionDto dto)
        {
            try
            {
                return Ok(await _client.Start(dto));
            }
            catch (Exception ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpPost("{id}/close")]
        public async Task<IActionResult> Close(long id)
        {
            try
            {
                return Ok(await _client.Close(id));
            }
            catch (Exception ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpPost("{id}/bid")]
        public async Task<IActionResult> Bid(long id, PlaceBidDto dto)
        {
            try
            {
                return Ok(await _client.Bid(id, dto));
            }
            catch (Exception ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var auction = await _client.Get(id);
            return auction == null ? NotFound() : Ok(auction);
        }

    }
}
