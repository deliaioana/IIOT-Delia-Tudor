using Microsoft.AspNetCore.Components;
using MotionSensor.UI.Pages.Models;
using MotionSensor.UI.Pages.Services;

namespace MotionSensor.UI.Pages
{
    public partial class AlertsOverview : ComponentBase
    {
        [Inject]
        public IAlertDataService AlertDataService { get; set; } = default!;

        public List<AlertModel> Alerts { get; set; } = new List<AlertModel>();

        protected override async Task OnInitializedAsync()
        {
            Alerts = (await AlertDataService.GetAllAlerts() ?? new List<AlertModel>()).ToList();
        }
    }
}