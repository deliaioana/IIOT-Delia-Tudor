using Microsoft.AspNetCore.Mvc;
using MotionSensor.Application.Repositories;

namespace MotionSensor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertsController : ControllerBase
    {
        private readonly IAlertRepository _alertRepository;

        public AlertsController(IAlertRepository alertRepository)
        {
            _alertRepository = alertRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_alertRepository.GetAll());
        }
    }
}
