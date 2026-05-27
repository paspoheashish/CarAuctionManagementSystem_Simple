using AuthService.Application.DTOs;
using AuthService.Application.Interfaces;
using AuthService.Infrastructure.Clients;

namespace AuthService.Application.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUserServiceClient _userClient;
        public AuthorizationService(IUserServiceClient userClient) {
            _userClient = userClient;
        }

        public async Task<UserValidationResponse?> Authorize(string email, string password)
        {
            var user = await _userClient.ValidateCredentials(email, password);
            return user;
        }
    }
}
