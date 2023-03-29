using MotionSensor.UI.Pages.Models;
using System.Text.Json;

namespace MotionSensor.UI.Pages.Services
{
    public class AlertDataService : IAlertDataService
    {
        private readonly string apiUrl = "https://localhost:7241/api/Alerts";
        private readonly HttpClient httpClient;

        public AlertDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<AlertModel>?> GetAllAlerts()
        {
            return await JsonSerializer
                .DeserializeAsync<IEnumerable<AlertModel>>
                (await httpClient.GetStreamAsync(apiUrl),
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                });
        }
    }
}
