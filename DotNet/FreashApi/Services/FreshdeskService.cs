
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
namespace FreashApi.Services
{
    public class FreshdeskService
    {
        private  HttpClient _httpClient;
        private readonly IConfiguration _config;

        public FreshdeskService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;

            var apiKey = _config["Freshdesk:ApiKey"];
            var baseUrl = _config["Freshdesk:BaseUrl"];

            _httpClient.BaseAddress = new Uri($"{baseUrl}/api/v2/");

            var byteArray = Encoding.ASCII.GetBytes($"{apiKey}:X");
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(byteArray));
        }

        public async Task<string> GetTickets()
        {
            var response = await _httpClient.GetAsync("tickets");
            Console.WriteLine("from the system");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<object> GetTicketById(int id)
        {
            var response = await _httpClient.GetAsync($"tickets/{id}");
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<object>(content);
        }
        public async Task<HttpResponseMessage> CreateTicket(object ticket)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(ticket),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("tickets", content);

            return response;
        }


        public async Task<string> UpdateTicket(int id, object ticket)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(ticket),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PutAsync($"tickets/{id}", content);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> DeleteTicket(int id)
        {
            var response = await _httpClient.DeleteAsync($"tickets/{id}");
            return await response.Content.ReadAsStringAsync();
        }
    }

}
