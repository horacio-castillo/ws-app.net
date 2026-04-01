using System;
using System.Collections.Generic;
using System.Text;
using wsApp.Domain.Entities;

namespace wsApp.Application.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetByEmailAsync(string email);
    }
}
