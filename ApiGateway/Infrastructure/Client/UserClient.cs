
namespace AuctionService.Infrastructure.Clients
{
    public class UserClient 
    {
        private readonly HttpClient _http;

        public UserClient(HttpClient http)
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
