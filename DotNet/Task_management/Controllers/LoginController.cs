using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_management.Data;
using Task_management.Models;
//using System.Linq;
//using System;

namespace Task_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private TaskManagementDBContext _dbContext;

        public LoginController(TaskManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Login(string username, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Name == username && u.Password == password);
            if (user != null)
            {
                return Ok(new { message = "Login successful" });
            }
            else
            {
                return BadRequest(new { message = "Invalid username or password" });
            }
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (user == null)
            {
                return BadRequest(new { message = "Invalid request" });
            }

            var existingUser = _dbContext.Users.FirstOrDefault(u => u.Name == user.Name);
            if (existingUser != null)
            {
                return BadRequest(new { message = "Username already exists" });


            }
            if (string.IsNullOrEmpty(user.Password)) {

                user.Password = "admin";
            }
            else
            {
                if(user.Password.Length < 6)
                {
                    return BadRequest(new { message = "Password must be at least 6 characters long" });
                }
                else if (!user.Password.Any(char.IsDigit) || !user.Password.Any(char.IsLetter))
                {
                    return BadRequest(new { message = "Password must contain at least one letter and one number" });
                }
                else if (user.Password.Contains(" "))
                {
                    return BadRequest(new { message = "Password cannot contain spaces" });
                }
                else
                {
                    user.Password = user.Password;    
                }
            }
            if (string.IsNullOrWhiteSpace(user.Role)) user.Role = "User";

            user.CreatedAt = DateTime.Now;
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return Ok(new { message = "Registration successful" });
        }
    }
}
