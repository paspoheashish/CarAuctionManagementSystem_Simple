using AuctionService.Infrastructure.Clients;
using ItemService.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemController : ControllerBase
    {
        private readonly ItemClient _client;

        public ItemController(ItemClient client)
        {
            _client = client;
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Add(AddVehicleDto dto)
        {
            var response = await _client.Add(dto);

            var content = await response.Content.ReadAsStringAsync();

            return StatusCode((int)response.StatusCode, content);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string? type, string? manufacturer, string? model, int? year)
        {
            var response = await _client.Search(type,  manufacturer,  model,  year);

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
