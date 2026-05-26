using AuctionService.Application.DTOs;
using AuctionService.Application.Interfaces;
using AuctionService.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AuctionService.Controllers
{
    [ApiController]
    [Route("api/auctions")]
    public class AuctionsController : Controller
    {
        private readonly IAuctionService _service;

        public AuctionsController(IAuctionService service)
        {
            _service = service;
        }

        [HttpPost("start")]
        public async Task<IActionResult> Start(StartAuctionDto dto)
        {
            try
            {
                return Ok(await _service.StartAuctionAsync(dto.VehicleId));
            }
            catch (Exception ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpPost("close/{id}")]
        public async Task<IActionResult> Close(long id)
        {
            try
            {
                return Ok(await _service.CloseAuctionAsync(id));
            }
            catch (Exception ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpPost("bid/{auctionId}")]
        public async Task<IActionResult> Bid(long auctionId, PlaceBidDto dto)
        {
            try
            {
                return Ok(await _service.PlaceBidAsync(auctionId, dto.Amount, dto.Bidder));
            }
            catch (Exception ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var auction = await _service.GetAuctionAsync(id);
            return auction == null ? NotFound() : Ok(auction);
        }
    }

}
