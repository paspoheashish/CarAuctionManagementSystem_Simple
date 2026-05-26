using AuctionService.Application.Interfaces;

namespace AuctionService.Infrastructure.Clients
{
    public class ItemServiceClient : IItemServiceClient
    {
        private readonly HttpClient _http;

        public ItemServiceClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> VehicleExists(long vehicleId)
        {
            var response = await _http.GetAsync($"http://localhost:5250/api/items/{vehicleId}");
            return response.IsSuccessStatusCode;
        }
    }
}
