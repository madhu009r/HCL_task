using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentService.Service;
using StudentService.DTO;

namespace StudentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParams pagination)
        {
            var result = await _service.GetAll(pagination);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await _service.GetById(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudent dto)
        {
            var result = await _service.Create(dto);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateStudent dto)
        {
            var result = await _service.Update(id, dto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.Delete(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
