using Microsoft.EntityFrameworkCore;
using wsApp.Application.Interfaces;
using wsApp.Domain.Entities;
using wsApp.Infrastructure.Persistence;

namespace wsApp.Infrastructure.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
