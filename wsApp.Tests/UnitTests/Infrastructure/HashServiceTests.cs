using Xunit;
using FluentAssertions;
using wsApp.Infrastructure.Security;

namespace wsApp.Tests.UnitTests.Infrastructure
{
    public class HashServiceTests
    {
        private readonly HashService _hashService;

        public HashServiceTests()
        {
            _hashService = new HashService();
        }

        [Fact]
        public void Hash_ShouldReturnHashedPassword()
        {
            // Arrange
            var password = "123456";

            // Act
            var result = _hashService.Hash(password);

            // Assert
            result.Should().NotBeNullOrEmpty();
            result.Should().NotBe(password);
        }

        [Fact]
        public void Verify_WithCorrectPassword_ShouldReturnTrue()
        {
            // Arrange
            var password = "123456";
            var hash = _hashService.Hash(password);

            // Act
            var result = _hashService.Verify(password, hash);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Verify_WithWrongPassword_ShouldReturnFalse()
        {
            // Arrange
            var password = "123456";
            var hash = _hashService.Hash(password);

            // Act
            var result = _hashService.Verify("wrongpassword", hash);

            // Assert
            result.Should().BeFalse();
        }
    }
}
