using wsApp.Application.DTOs;
using wsApp.Application.Interfaces;
using wsApp.Domain.Entities;

namespace wsApp.Application.UseCases
{
    public class RegisterUserUseCase
    {
        private readonly IUserRepository _repo;

        public RegisterUserUseCase(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task Execute(RegisterUserDto dto)
        {
            var user = new User
            {
                Email = dto.Email,
                PasswordHash = dto.Password,  
                Name = dto.Name,
                CreatedAt = DateTime.UtcNow
            };

            await _repo.AddAsync(user);
        }
    }
}
