using AuthService.Application.DTOs;

namespace AuthService.Application.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(UserValidationResponse user);
    }
}
