using ItemService.Application.DTOs;
using ItemService.Application.Interfaces;
using ItemService.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItemService.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemsController : Controller
    {
        private readonly IVechicleService _service;

        public ItemsController(IVechicleService service)
        {
            _service = service;
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Add(AddVehicleDto dto)
        {
            try
            {
                return Ok(await _service.AddVehicleAsync(dto));
            }
            catch (Exception ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string? type, string? manufacturer, string? model, int? year)
        {
            return Ok(await _service.SearchAsync(type, manufacturer, model, year));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return Ok(await _service.GetAsync(id));
        }
    }

}
