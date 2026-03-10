using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Task_Management2.Data;
using Task_Management2.Model;
using Microsoft.IdentityModel.Tokens;

namespace Task_Management2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private AppDbContext _context;
        private IConfiguration _configuration;

        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public IActionResult register(User us)
        {
            Console.WriteLine("getting into the register");
            if (us == null || string.IsNullOrEmpty(us.Email))
            {
                
                return BadRequest(new { message = "Invalid user data" });
            }
            //checking existing user
            var existingUser = _context.users.FirstOrDefault(u => u.Email == us.Email);
            if(existingUser == null)
            {
                Console.WriteLine("creating new user");
                _context.users.Add(us);
                _context.SaveChanges();

                return Ok(new { message = "user registered succesfully" });
            }

            return BadRequest(new { message = " user with this email already exists" });
        }

        //login
        [HttpPost("login")]
        public IActionResult login(User us) {

           
           Console.WriteLine("getting user details");
           var user = _context.users.FirstOrDefault(u => u.Email == us.Email && u.PasswordHash == us.PasswordHash);

           if(user == null)
            {
                return BadRequest(new { message = "Invalid email or Password, try to login again" });
            }
            var token = GenerateJwtToken(user);


            return Ok(new { token = token, _role = user.role });
        }

        public string GenerateJwtToken(User user)
        {
            Console.WriteLine("Generating Jwt token");

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.role)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            Console.WriteLine("Creating Jwt token");

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: creds
                );
            Console.WriteLine(token);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
