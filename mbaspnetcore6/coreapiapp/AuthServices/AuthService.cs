using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace coreapiapp.AuthServices
{
    /// <summary>
    /// The Logic for Registering and Autenticating User
    /// using the UserManager<IdentityUser> and SignInManager<IdentityUser> classes
    /// To CReate and Authenticate User
    /// Use IConfiguration Interface to Read appsettings.json 
    /// </summary>
    public class AuthService
    {

        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        IConfiguration _configuration;

        public AuthService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        /// <summary>
        /// Register New User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ResponseStatus<RegisterUser>> RegisterUserAsync(RegisterUser user)
        {
            ResponseStatus<RegisterUser> response = new ResponseStatus<RegisterUser>();

            var userToRegister = new IdentityUser() {UserName = user.Email, Email = user.Email };

            var status = await _userManager.CreateAsync(userToRegister, user.Password);
            if (status.Succeeded)
            {
                response.Message = $"User {user.Email} Is Created Successfully";
            }
            else
            {
                response.Message = $"User {user.Email} Creation is Failed";
            }

            return response;
        }
        /// <summary>
        /// Authenticate User and Generate Token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ResponseStatus<LoginUser>> AuthenticateUserAsync(LoginUser user)
        {
            ResponseStatus<LoginUser> response = new ResponseStatus<LoginUser>();
            // 1. Authenticate User

            var loginStatus = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, lockoutOnFailure: false);

            if (loginStatus.Succeeded)
            {
                // 1.a. Read Signeture and Expity Time for token
                var secreySinKey = Convert.FromBase64String( _configuration["JwtSettings:Signeture"]);
                var expiry = Convert.ToDouble( _configuration["JwtSettings:ExpityInMinuts"]);

                // 1.b. Craeet an IdentityUser object against which the Topken will be generated
                var identityUser = new IdentityUser(user.UserName);

                // 1.c. Logicn to Generate token
                var tokenDescription = new SecurityTokenDescriptor()
                {
                     Issuer = null,
                     Audience = null,
                     Subject = new ClaimsIdentity(new List<Claim> { new Claim("username", identityUser.Id.ToString())}),
                     Expires = DateTime.UtcNow.AddMinutes(expiry),
                     IssuedAt = DateTime.UtcNow,
                     NotBefore = DateTime.UtcNow,
                     SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secreySinKey), SecurityAlgorithms.HmacSha256Signature)
                };

                // 1.d. Write a Token as Header.Payload.Signeture
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwToken = tokenHandler.CreateJwtSecurityToken(tokenDescription);
                response.Message = tokenHandler.WriteToken(jwToken);
            }
            else
            {
                response.Message = $"Login Failed for User {user.UserName}";
            }


            return response;
        }


       
    }
}

