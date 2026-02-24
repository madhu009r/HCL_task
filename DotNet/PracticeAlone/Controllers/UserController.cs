using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeAlone.Data;

namespace PracticeAlone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserDbContext _context;

        public UserController(UserDbContext context) {  _context = context; }

    

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _context.Users
                .ToList();
            return Ok(students);
        }
    }
}
