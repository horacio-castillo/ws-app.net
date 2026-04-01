using wsApp.Application.DTOs;
using wsApp.Application.Interfaces;
using wsApp.Domain.Entities;

namespace wsApp.Application.UseCases
{
    public class RegisterUserUseCase
    {
        private readonly IUserRepository _repo;
        private readonly IHashService _hash;

        public RegisterUserUseCase(IUserRepository repo, IHashService hash)
        {
            _repo = repo;
            _hash = hash;
        }

        public async Task Execute(RegisterUserDto dto)
        {
            var hashedPassword = _hash.Hash(dto.Password);

            var user = new User
            {
                Email = dto.Email,
                PasswordHash = hashedPassword,  
                Name = dto.Name,
                CreatedAt = DateTime.UtcNow
            };

            await _repo.AddAsync(user);
        }
    }
}
