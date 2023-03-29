using MotionSensor.Domain;

namespace MotionSensor.Application.Repositories
{
    public interface IRFIDMotionSensorRepository
    {
        void Add(RFIDMotionSensor motionSensor);
        void Delete(RFIDMotionSensor motionSensor);
        RFIDMotionSensor Get(Guid id);
        List<RFIDMotionSensor> GetAll();
        void Save();
    }
}