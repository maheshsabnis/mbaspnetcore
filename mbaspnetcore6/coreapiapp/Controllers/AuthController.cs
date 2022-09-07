using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using coreapiapp.AuthServices;
using coreapiapp.Models;

namespace coreapiapp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private AuthService service;
        public AuthController(AuthService serv)
        {
            service = serv;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser user)
        {
            var result = await service.RegisterUserAsync(user);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUser user)
        {
            var result = await service.AuthenticateUserAsync(user);
            return Ok(result);
        }
    }
}
