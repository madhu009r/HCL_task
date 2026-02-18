using FetchApi.Data;
using FetchApi.LoR;
using FetchApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FetchApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _appDb;
        //DI
        public AuthController(AppDbContext appDb)
        {
            _appDb = appDb;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(Register _register)
        {
            if (await _appDb.Users.AnyAsync(u => u.Username == _register.Username))
                return BadRequest("Username already exists");

            var user = new User
            {
                Username = _register.Username,
                Password = _register.Password
            };
            _appDb.Users.Add(user);
            await _appDb.SaveChangesAsync();

            return Ok("User registered successfully");

        }

        [HttpPost("login")]

        public async Task<IActionResult> Login(Login _login)
        {
            var user = await _appDb.Users
                .FirstOrDefaultAsync(u=> u.Username==_login.Username && u.Password==_login.Password);
            if (user == null) return Unauthorized("Invalid ceredential");

            return Ok(new { userId = user.Id, username = user.Username });
        }



    }

}
