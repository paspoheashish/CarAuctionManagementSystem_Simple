
namespace AuctionService.Infrastructure.Clients
{
    public class NotificationClient
    {
        private readonly HttpClient _http;

        public NotificationClient(HttpClient http)
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
