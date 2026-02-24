using BookAPI.Data;
using BookAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private BookDbContext _context;

        public BookController(BookDbContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IActionResult GetallBooks()
        {
            
            return Ok(_context.Books);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Book>> GetById(int Id)
        {
            var book = await _context.Books
                .FindAsync(Id );

            if (book == null)
                return NotFound();

            return Ok(book);
        }



        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteStudent(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                return Ok("Id Deleted Successfully");
            }
            else
            {
                return BadRequest("Id not found");

            }
        }

        [HttpPost("{id}")]

        public IActionResult Create(Book books)
        {
            if (_context.Books != null)
            {
                _context.Books.Add(books);
                _context.SaveChanges();
                return Ok("student is added");
            }
            else
            {
                return BadRequest("No Students Found");
            }
        }

    }
}
