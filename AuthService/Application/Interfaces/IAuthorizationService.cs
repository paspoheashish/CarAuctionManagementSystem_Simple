using AuthService.Application.DTOs;

namespace AuthService.Application.Interfaces
{
    public interface IAuthorizationService
    {
        Task<UserValidationResponse?> Authorize(string email, string password);
    }
}
