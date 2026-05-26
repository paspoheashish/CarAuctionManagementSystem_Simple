using AuthService.Application.DTOs;
using AuthService.Application.Interfaces;

namespace AuthService.Infrastructure.Clients
{
    public class UserServiceClient : IUserServiceClient
    {
        private readonly HttpClient _http;

        public UserServiceClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<UserValidationResponse?> ValidateCredentials(string email, string password)
        {
            var response = await _http.PostAsJsonAsync("/api/users/validate", new
            {
                Email = email,
                Password = password
            });

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<UserValidationResponse>();
        }
    }

}
