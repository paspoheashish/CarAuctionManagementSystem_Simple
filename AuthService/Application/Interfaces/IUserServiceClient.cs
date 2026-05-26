using AuthService.Application.DTOs;

namespace AuthService.Application.Interfaces
{
    public interface IUserServiceClient
    {
        Task<UserValidationResponse?> ValidateCredentials(string email, string password);
    }
}
