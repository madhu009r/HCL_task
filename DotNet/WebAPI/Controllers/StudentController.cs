using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private IConfiguration _configuration;
        MySqlConnection _connection;
        public StudentController(IConfiguration _configuration)
        {
            this._configuration = _configuration;
            var conStr = _configuration.GetConnectionString("DefaultConnection");
            _connection = new MySqlConnection(conStr);
            _connection.Open();
        }

        [HttpGet]
        public IActionResult GetStudent()
        {
            string query = "Select * from student";

            var cmd = new MySqlCommand(query, _connection);
           
            var reader = cmd.ExecuteReader();
            List<Student> students = new List<Student>();

            while (reader.Read())
            {
                var student = new Student
                {
                    Id = reader.GetInt32("Id"),
                    Name = reader.GetString("Name")
                };
                students.Add(student);

            }
            return Ok(students);

        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody]Student student)
        {
            string query = "Insert into student value(@id, @name)";
            var cmd = new MySqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@id", student.Id);
            cmd.Parameters.AddWithValue("@name", student.Name);
            int count = cmd.ExecuteNonQuery();
            if (count == 1)
            {
                return Ok(student);
            }
            else
            {
                return BadRequest();
            }

        }


        [HttpPut]
        public IActionResult UpdateStudent(Student student)
        {
            string query = "update student set Name=@name where Id=@id";
            var cmd = new MySqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@id", student.Id);
            cmd.Parameters.AddWithValue("@name", student.Name);
            int count = cmd.ExecuteNonQuery();
            if (count == 1)
            {
                return Ok(student);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            string query = "delete from student where id=@id";
            var cmd = new MySqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@id", id);
            int count = cmd.ExecuteNonQuery();

            if (count == 1)
            {
                return Ok($"Deleted id is: {id}");
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
