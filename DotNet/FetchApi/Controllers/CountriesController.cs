using System.Text.Json;
using FetchApi.LoR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FetchApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public CountriesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> getCountries()
        {
            var response = await _httpClient.GetAsync("https://restcountries.com/v3.1/all?fields=name,cca2,region,capital,flags");

            if (!response.IsSuccessStatusCode)
                return BadRequest("Failed to fetch countries");

            var content = await response.Content.ReadAsStringAsync();
            var json = JsonDocument.Parse(content);

            var result = json.RootElement.EnumerateArray()
                .Select(c => new Countries
                {
                    Name = c.GetProperty("name").GetProperty("common").GetString(),
                    Capital = c.TryGetProperty("capital", out var cap) ? cap[0].GetString() : "",
                    Region = c.GetProperty("region").GetString(),
                    FlagUrl = c.GetProperty("flags").GetProperty("png").GetString()
                })
                .ToList();

            return Ok(result); 
        }
    }
}
