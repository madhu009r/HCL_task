using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Management2.Data;
using Task_Management2.Model;

namespace Task_Management2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private AppDbContext _context;

        public TaskController(AppDbContext context)
        {
            _context = context;
        }

        // Implement task-related actions here (e.g., create, read, update, delete tasks)
       
        [HttpGet]
        public IActionResult GetTaskById(int id)
        {
            //here the user mean logged member, first need to get the logged member id then get the task by id
            Console.WriteLine("getting Logged_userId from JWT token");

           
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            //User should only see their own tasks.
             var tasks = _context.tasksItems.Where(t => t.CreatedBy == userId).ToList();
             
            return Ok(tasks);
        }

        [HttpPost]
        public IActionResult CreateTask(TasksItem task)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            task.CreatedBy = userId;
            task.Status = "Pending";

            _context.tasksItems.Add(task);
            _context.SaveChanges();

            return Ok("Task Created");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, TasksItem updatedTask)
        {
            var task = _context.tasksItems.Find(id);

            if (task == null)
            {
                return NotFound();
            }

            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.DueDate = updatedTask.DueDate;
            task.Status = updatedTask.Status;

            _context.SaveChanges();

            return Ok("Task Updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = _context.tasksItems.Find(id);

            if (task == null)
            {
                return NotFound();
            }

            _context.tasksItems.Remove(task);
            _context.SaveChanges();

            return Ok("Task Deleted");
        }
    }
}
