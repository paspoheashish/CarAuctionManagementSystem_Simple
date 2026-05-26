using AuctionService.Infrastructure.Clients;
using ItemService.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    public class ItemController : Controller
    {
        private readonly ItemClient _client;

        public ItemController(ItemClient client)
        {
            _client = client;
        }

        [HttpPost]
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
