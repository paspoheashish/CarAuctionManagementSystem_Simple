using UserService.Application.DTOs;
using UserService.Domain.Entities;

namespace UserService.Application.Interfaces
{
    public interface IUserService
    {
        Task<User?> ValidateAsync(string email, string password);
        Task<User?> GetByEmailAsync(string email);
        Task<User> CreateUserAsync(CreateUserDto dto);
    }
}
