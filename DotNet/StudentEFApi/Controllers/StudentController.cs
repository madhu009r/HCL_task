using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentEFApi.Data;
using StudentEFApi.Model;

namespace StudentEFApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        StudentDbContext context;

        public StudentController(StudentDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {

            
                return Ok(context.student);
            
            //return BadRequest("No students found.");
        }

        [HttpPost("{id}")]

        public IActionResult Create(Student student)
        {
            if (context.student != null)
            {
                context.student.Add(student);
                context.SaveChanges();
                return Ok("student is added");
            }
            else
            {
                return BadRequest("No Students Found");
            }
        }

        [HttpPut("{id}")]

        public IActionResult UpdateStudent(int id, Student student)
        {
            if (student != null)
            {
                context.student.Update(student);
                context.SaveChanges();
                return Ok("Student Updated");
            }
            else
            {
                return BadRequest("Student not found");
            }
        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteStudent(int id)
        {
            var students = await context.student.FindAsync(id);
            if (students != null)
            {
                context.student.Remove(students);
                context.SaveChanges();
                return Ok("Id Deleted Successfully");
            }
            else
            {
                return BadRequest("Id not found");

            }
        }

    }
}
