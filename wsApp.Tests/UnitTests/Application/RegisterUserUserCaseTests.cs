using Moq;
using Scalar.AspNetCore;
using wsApp.Application.DTOs;
using wsApp.Application.Interfaces;
using wsApp.Application.UseCases;
using wsApp.Domain.Entities;

namespace wsApp.Tests.UnitTests.Application
{
    public class RegisterUserUserCaseTests
    {
        private readonly Mock<IUserRepository> _repoMock; 
        private readonly Mock<IHashService> _hashMock;
        private readonly RegisterUserUseCase _useCase;

        public RegisterUserUserCaseTests()
        {
            _repoMock = new Mock<IUserRepository>();
            _hashMock = new Mock<IHashService>();
            _useCase = new RegisterUserUseCase(_repoMock.Object, _hashMock.Object);
        }

        //Happy Path
        [Fact]
        public async Task Execute_ShouldRegisterUser()
        {
            // Arrange
            var dto = new RegisterUserDto
            {
                Email = "test@test.com",
                Password = "123",
                Name = "Test User"
            };

            _hashMock.Setup(h => h.Hash(dto.Password)).Returns("hashedPassword");

            await _useCase.Execute(dto);

            _hashMock.Verify(h => h.Hash(dto.Password), Times.Once);
        }


        [Fact]
        public async Task Execute_ShouldCallAddAsync()
        {
            // Arrange
            var dto = new RegisterUserDto
            {
                Email = "test@test.com",
                Password = "123456",
                Name = "Test User"
            };

            _hashMock
                .Setup(h => h.Hash(dto.Password))
                .Returns("hashedpassword");

            // Act
            await _useCase.Execute(dto);

            // Assert — verificamos que se guardó el usuario
            _repoMock.Verify(
                r => r.AddAsync(It.Is<User>(u =>
                    u.Email == dto.Email &&
                    u.Name == dto.Name &&
                    u.PasswordHash == "hashedpassword"
                )),
                Times.Once
            );
        }
    }
}
