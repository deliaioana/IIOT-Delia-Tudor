using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MotionSensor.UI.Pages.Services;

namespace LabsCourseManagement.UI
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddUIServices(this IServiceCollection services, IWebAssemblyHostEnvironment env)
        {
            services.AddHttpClient<IAlertDataService, AlertDataService>
            (
                client => client.BaseAddress
                = new Uri(env.BaseAddress)
            );

            return services;
        }
    }
}