using UserService.Domain.Entities;

namespace UserService.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAndPasswordAsync(string email, string password);
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
    }
}
