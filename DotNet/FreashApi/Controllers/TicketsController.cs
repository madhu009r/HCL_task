using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FreashApi.Services;

namespace FreashApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly FreshdeskService _service;

        public TicketsController(FreshdeskService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetTickets()
        {
            var result = await _service.GetTickets();
            return Content(result, "application/json");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicket(int id)
        {
            var result = await _service.GetTicketById(id);
            return Ok(result);
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] object ticket)
        {
            var response = await _service.CreateTicket(ticket);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, content);
            }

            return Ok(content);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, [FromBody] object ticket)
        {
            var result = await _service.UpdateTicket(id, ticket);
            return Content(result, "application/json");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var result = await _service.DeleteTicket(id);
            return Content(result, "application/json");
        }
    }

}
