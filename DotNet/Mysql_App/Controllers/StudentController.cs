using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mysql_App.Models;

namespace Mysql_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private StudentController context;
         

        [HttpGet]
        public ActionResult<List<Student>> GetStudents()
        {
            var students = new List<Student>
    {
        new Student { Id = 1, Name = "John"},
        new Student { Id = 2, Name = "Alice"}
    };

            return Ok(students);
        }
    }
}
