using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotionSensor.Application.Repositories;
using MotionSensor.Domain;
using MotionSensor.WebAPI.Dtos;
using System.Diagnostics.Metrics;

namespace MotionSensor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotionSensorsController : ControllerBase
    {
        private readonly IRFIDMotionSensorRepository _motionSensorRepository;
        private readonly IAlertRepository _alertRepository;

        public MotionSensorsController(IRFIDMotionSensorRepository motionSensorRepository, IAlertRepository alertRepository)
        {
            _motionSensorRepository = motionSensorRepository;
            _alertRepository = alertRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_motionSensorRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create(CreateMotionSensorDto motionSensorDto)
        {
            var motionSensorResult = RFIDMotionSensor.Create(motionSensorDto.Address);

            if (motionSensorResult.IsFailure)
            {
                return BadRequest(motionSensorResult.Error);
            }

            _motionSensorRepository.Add(motionSensorResult.Entity);
            _motionSensorRepository.Save();
            return Ok(motionSensorResult.Entity);
        }

        [HttpPost("{motionSensorId:guid}/alert")]
        public IActionResult AddAlert(Guid motionSensorId)
        {
            var motionSensor = _motionSensorRepository.Get(motionSensorId);
            if (motionSensor == null)
            {
                return NotFound($"Motion Sensor with id {motionSensorId} does not exist");
            }

            var alertResult = Alert.Create(motionSensor);
            if(alertResult.IsFailure)
            {
                return BadRequest(alertResult.Error);
            }

            _alertRepository.Add(alertResult.Entity);
            _alertRepository.Save();

            motionSensor.AddAlert(alertResult.Entity);
            _motionSensorRepository.Save();

            return NoContent();
        }
    }
}
