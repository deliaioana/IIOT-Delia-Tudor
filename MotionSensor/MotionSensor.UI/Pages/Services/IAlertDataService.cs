using MotionSensor.UI.Pages.Models;

namespace MotionSensor.UI.Pages.Services
{
    public interface IAlertDataService
    {
        Task<IEnumerable<AlertModel>?> GetAllAlerts();
    }
}