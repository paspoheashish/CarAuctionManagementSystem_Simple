using UserService.Application.DTOs;

namespace ApiGateway.Application.Interfaces
{
    public interface IUserClient
    {
        Task<HttpResponseMessage> GetUser(string email);
        Task<HttpResponseMessage> Register(CreateUserDto dto);
        Task<HttpResponseMessage> Validate(ValidateCredentialsDto dto);
    }
}
