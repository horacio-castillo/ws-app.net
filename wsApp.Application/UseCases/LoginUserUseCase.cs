using System;
using System.Collections.Generic;
using System.Text;
using wsApp.Application.DTOs;
using wsApp.Application.Interfaces;

namespace wsApp.Application.UseCases
{
    public class LoginUserUseCase
    {
        private readonly IUserRepository _repo;
        private readonly IHashService _hash;
        private readonly IJwtService _jwt;

        public LoginUserUseCase(
            IUserRepository repo,
            IHashService hash,
            IJwtService jwt)
        {
            _repo = repo;
            _hash = hash;
            _jwt = jwt;
        }

        public async Task<string> Execute(LoginDto dto)
        {
            var user = await _repo.GetByEmailAsync(dto.Email);

            if (user == null)
                throw new Exception("Usuario no encontrado");

            var valid = _hash.Verify(dto.Password, user.PasswordHash);

            if (!valid)
                throw new Exception("Password incorrecto");

            var token = _jwt.GenerateToken(user.Id.ToString(), user.Email);

            return token;
        }
    }
}
