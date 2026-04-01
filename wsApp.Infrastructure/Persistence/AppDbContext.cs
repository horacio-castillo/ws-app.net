using Microsoft.EntityFrameworkCore;
using wsApp.Domain.Entities;

namespace wsApp.Infrastructure.Persistence
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
