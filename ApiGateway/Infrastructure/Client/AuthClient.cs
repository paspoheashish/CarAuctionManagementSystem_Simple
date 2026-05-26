
using ApiGateway.Application.Interfaces;
using AuthService.Application.DTOs;

namespace AuctionService.Infrastructure.Clients
{
    public class AuthClient : IAuthClient
    {
        private readonly HttpClient _http;

        public AuthClient(HttpClient http)
        {
            _http = http;
        }
                
        public async Task<HttpResponseMessage> Login(LoginRequest request)
        {
            var response = await _http.PostAsJsonAsync($"http://localhost:5073/api/Auth/login", request);
            return response;
        }
    }
}
