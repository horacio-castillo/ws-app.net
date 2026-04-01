using System;
using System.Collections.Generic;
using System.Text;

namespace wsApp.Application.Interfaces
{
    public interface IHashService
    {
        string Hash(string password);
        bool Verify(string password, string hash);
    }
}
