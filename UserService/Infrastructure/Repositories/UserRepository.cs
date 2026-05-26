using UserService.Application.Interfaces.Repositories;
using UserService.Domain.Entities;
using UserService.Infrastructure.DBContext;

namespace UserService.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _appContext;

        public UserRepository(AppDBContext appContext)
        {
            _appContext = appContext;
        }

        public Task AddAsync(User user)
        {
            _appContext.Users.Add(user);
            return Task.CompletedTask;
        }

        public Task<User?> GetByEmailAsync(string email)
        {
            var user = _appContext.Users.FirstOrDefault(x => x.Email == email);
            return Task.FromResult<User?>(user);
        }

        public Task<User?> GetByEmailAndPasswordAsync(string email, string password)
        {
            var user = _appContext.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
            return Task.FromResult<User?>(user);
        }
    }

}
