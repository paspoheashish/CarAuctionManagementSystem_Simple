using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using UserService.Application.Interfaces.Repositories;
using UserService.Application.Services;
using UserService.Application.DTOs;
using UserService.Domain.Entities;

namespace UserService.Test
{
    public class UserServiceSimpleTests
    {
        private Mock<IUserRepository> repo = null!;
        private Mock<UserService.Application.Interfaces.Repositories.IUnitOfWork> uow = null!;
        private UserService.Application.Services.UserService service = null!;

        [SetUp]
        public void Setup()
        {
            repo = new Mock<IUserRepository>();
            uow = new Mock<UserService.Application.Interfaces.Repositories.IUnitOfWork>();
            service = new UserService.Application.Services.UserService(uow.Object, repo.Object);
        }

        [Test]
        public async Task CreateUser_ReturnsCreatedUser()
        {
            uow.Setup(u => u.SaveAsync()).ReturnsAsync(1);
            repo.Setup(r => r.AddAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

            var dto = new CreateUserDto { FirstName = "ap", LastName = "ap", Email = "ap@gmail.com", Password = "ap1234" };
            var result = await service.CreateUserAsync(dto);

            Assert.That(result.Email, Is.EqualTo(dto.Email));
        }
    }
}
