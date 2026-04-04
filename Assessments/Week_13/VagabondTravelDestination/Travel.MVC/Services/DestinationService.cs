using System.Text.Json;
using Travel.MVC.Models;

namespace Travel.MVC.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly HttpClient _http;

        public DestinationService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<Destination>> GetAllAsync()
        {
            var response = await _http.GetAsync("api/destinations");

            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<Destination>>(data,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                ?? new List<Destination>();
        }
    }
}
