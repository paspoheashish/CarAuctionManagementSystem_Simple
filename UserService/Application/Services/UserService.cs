using Microsoft.AspNetCore.Identity;
using UserService.Application.DTOs;
using UserService.Application.Interfaces;
using UserService.Application.Interfaces.Repositories;
using UserService.Domain.Entities;

namespace UserService.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<User?> ValidateAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAndPasswordAsync(email, password);
            if (user == null) return null;

            return user;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            User? user = null;
            user = await _userRepository.GetByEmailAsync(email);
                if (user == null) return null;              

            return user;
        }

        public async Task<User> CreateUserAsync(CreateUserDto dto)
        {
            var user = new User(dto.FirstName, dto.LastName, dto.Email, dto.Password);
            await _userRepository.AddAsync(user);
            await _unitOfWork.SaveAsync();
            return user;
        }
    }
}
