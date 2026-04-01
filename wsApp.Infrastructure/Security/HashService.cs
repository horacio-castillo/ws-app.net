
using BCrypt.Net;
using wsApp.Application.Interfaces;

namespace wsApp.Infrastructure.Security
{
    public class HashService: IHashService
    {
        public string Hash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool Verify(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
