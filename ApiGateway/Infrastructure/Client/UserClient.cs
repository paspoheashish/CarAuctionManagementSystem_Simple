
using ApiGateway.Application.Interfaces;
using AuctionService.Application.DTOs;
using UserService.Application.DTOs;

namespace AuctionService.Infrastructure.Clients
{
    public class UserClient : IUserClient
    {
        private readonly HttpClient _http;

        public UserClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<HttpResponseMessage> GetUser(string email)
        {
            var response = await _http.GetAsync($"http://localhost:5253/api/users/{email}");
            return response;
        }

        public async Task<HttpResponseMessage> Register(CreateUserDto dto)
        {
            var response = await _http.PostAsJsonAsync($"http://localhost:5253/api/users/register", dto);
            return response;
        }

        public async Task<HttpResponseMessage> Validate(ValidateCredentialsDto dto)
        {
            var response = await _http.PostAsJsonAsync($"http://localhost:5253/api/users/validate", dto);
            return response;
        }
    }
}
