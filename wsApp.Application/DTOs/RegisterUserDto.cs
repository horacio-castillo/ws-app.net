using System;
using System.Collections.Generic;
using System.Text;

namespace wsApp.Application.DTOs
{
    public class RegisterUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
