using ApiGateway.Application.Interfaces;
using Asp.Versioning;
using AuctionService.Infrastructure.Clients;
using ItemService.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/items")]
    [ApiVersion("1.0")]
    public class ItemController : ControllerBase
    {
        private readonly IItemClient _client;

        public ItemController(IItemClient client)
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
