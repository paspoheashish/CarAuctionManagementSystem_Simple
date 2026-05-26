
using ApiGateway.Application.Interfaces;
using AuctionService.Application.DTOs;

namespace AuctionService.Infrastructure.Clients
{
    public class AuctionClient : IAuctionClient
    {
        private readonly HttpClient _http;

        public AuctionClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<HttpResponseMessage> Get(long vehicleId)
        {
            var response = await _http.GetAsync($"http://localhost:5117/api/auctions/{vehicleId}");
            return response;
        }

        public async Task<HttpResponseMessage> Bid(long auctionId, PlaceBidDto dto)
        {
            var response = await _http.PostAsJsonAsync($"http://localhost:5117/api/auctions/bid/{auctionId}", dto);
            return response;
        }

        public async Task<HttpResponseMessage> Close(long id)
        {
            var response = await _http.PostAsJsonAsync($"http://localhost:5117/api/auctions/close/{id}", new { });
            return response;
        }

        public async Task<HttpResponseMessage> Start(StartAuctionDto dto)
        {
            var response = await _http.GetAsync($"http://localhost:5117/api/auctions/start");
            return response;
        }
    }
}
