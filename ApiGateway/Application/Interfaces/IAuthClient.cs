using AuthService.Application.DTOs;

namespace ApiGateway.Application.Interfaces
{
    public interface IAuthClient
    {
        Task<HttpResponseMessage> Login(LoginRequest request);
    }
}
