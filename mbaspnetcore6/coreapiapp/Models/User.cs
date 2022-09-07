using System;
namespace coreapiapp.Models
{
    public class RegisterUser
    {
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class LoginUser
    {
        public string UserName { get; set; } = String.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class ServiceResponse
    {
        public string Token { get; set; } = string.Empty;
    }
}

