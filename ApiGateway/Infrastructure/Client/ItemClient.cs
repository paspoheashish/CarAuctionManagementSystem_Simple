
using ApiGateway.Application.Interfaces;
using AuctionService.Application.DTOs;
using ItemService.Application.DTOs;

namespace AuctionService.Infrastructure.Clients 
{
    public class ItemClient : IItemClient
    {
        private readonly HttpClient _http;

        public ItemClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<HttpResponseMessage> Search(string? type, string? manufacturer, string? model, int? year)
        {
            var response = await _http.GetAsync($"http://localhost:5250/api/items?type={type}&manufacturer={manufacturer}&model={model}&year={year}");
            return response;
        }

        public async Task<HttpResponseMessage> Get(long id)
        {
            var response = await _http.GetAsync($"http://localhost:5250/api/items/{id}");
            return response;
        }

        public async Task<HttpResponseMessage> Add(AddVehicleDto dto)
        {
            var response = await _http.PostAsJsonAsync($"http://localhost:5250/api/auctions/Save", dto);
            return response;
        }

    }
}
