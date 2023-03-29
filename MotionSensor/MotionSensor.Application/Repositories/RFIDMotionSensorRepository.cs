using Microsoft.EntityFrameworkCore;
using MotionSensor.Domain;

namespace MotionSensor.Application.Repositories
{
    public class RFIDMotionSensorRepository : IRFIDMotionSensorRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public RFIDMotionSensorRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Add(RFIDMotionSensor motionSensor)
        {
            _databaseContext.MotionSensors.Add(motionSensor);
        }

        public List<RFIDMotionSensor> GetAll()
        {
            return _databaseContext.MotionSensors.Include(e => e.AlertsList).ToList();
        }

        public RFIDMotionSensor Get(Guid id)
        {
            return _databaseContext.MotionSensors.Include(e => e.AlertsList).FirstOrDefault(e => e.Id == id);
        }

        public void Delete(RFIDMotionSensor motionSensor)
        {
            _databaseContext.MotionSensors.Remove(motionSensor);
        }

        public void Save()
        {
            _databaseContext.Save();
        }
    }
}
