using AuctionService.Application.DTOs;
using AuctionService.Infrastructure.Clients;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [ApiController]
    [Route("api/Auctions")]
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
            var response = await _client.Start(dto);

            var content = await response.Content.ReadAsStringAsync();

            return StatusCode((int)response.StatusCode, content);
        }

        [HttpPost("{id}/close")]
        public async Task<IActionResult> Close(long id)
        {
            var response = await _client.Close(id);

            var content = await response.Content.ReadAsStringAsync();

            return StatusCode((int)response.StatusCode, content);
        }

        [HttpPost("{id}/bid")]
        public async Task<IActionResult> Bid(long id, PlaceBidDto dto)
        {
            var response = await _client.Bid(id, dto);

            var content = await response.Content.ReadAsStringAsync();

            return StatusCode((int)response.StatusCode, content);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var response = await _client.Get(id);

            var content = await response.Content.ReadAsStringAsync();

            return StatusCode((int)response.StatusCode, content);
        }

    }
}
