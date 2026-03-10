using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Management2.Data;

namespace Task_Management2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var users = _context.users.ToList();

            return Ok(users);
        }

        [HttpGet("tasks")]
        public IActionResult GetAllTasks()
        {
            var tasks = _context.tasksItems.ToList();

            return Ok(tasks);
        }

        [HttpGet("dashboard")]
        public IActionResult GetDashboard()
        {
            var totalUsers = _context.users.Count();
            var totalTasks = _context.tasksItems.Count();
            var completedTasks = _context.tasksItems.Count(t => t.Status == "Completed");

            var result = new
            {
                TotalUsers = totalUsers,
                TotalTasks = totalTasks,
                CompletedTasks = completedTasks
            };

            return Ok(result);
        }
    }
}

