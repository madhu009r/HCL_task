using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_management.Data;
using Task_management.Models;

namespace Task_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskCreateController : ControllerBase
    {
        private TaskManagementDBContext _dbContext;

        public TaskCreateController(TaskManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]

        public IActionResult CreateTask(TaskList task)
        {
            if (task == null)
            {
                return BadRequest(new { message = "Invalid request" });
            }
            _dbContext.TaskLists.Add(task);
            _dbContext.SaveChanges();
            return Ok(new { message = "Task created successfully" });
        }

        [HttpPut]

        public IActionResult UpdateTask([FromBody] TaskList task ,[FromHeader]int id)
        { 
            var existingTask = _dbContext.TaskLists.FirstOrDefault(t => t.TaskId == id);

            if (existingTask != null)
            { 
                existingTask.TaskId = id;
                existingTask.TaskName = task.TaskName;
                existingTask.AssignTo = task.AssignTo;
                existingTask.Descrip = task.Descrip;
                existingTask.DueDate = task.DueDate;

                existingTask.CreatedAt = DateTime.Now;
            }else
            {
                return NotFound(new { message = "Task not found" });
            }
            return Ok(new { message = "Task updated successfully" });

        }

        [HttpDelete]
        public IActionResult DeleteTask(string TaskName)
        {

            if (string.IsNullOrEmpty(TaskName))
            {
                return BadRequest(new { message = "Invalid request" });
            }

            var existingTask = _dbContext.TaskLists.FirstOrDefault(t => t.TaskName == TaskName);

            if (existingTask != null)
            {
                _dbContext.TaskLists.Remove(existingTask);
                _dbContext.SaveChanges();
                return Ok(new { message = "Task deleted successfully" });

            }
            else
            {
                return NotFound(new { message = "Task not found" });

            }
        }
    }
}
