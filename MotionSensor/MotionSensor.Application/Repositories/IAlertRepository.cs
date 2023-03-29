using MotionSensor.Domain;

namespace MotionSensor.Application.Repositories
{
    public interface IAlertRepository
    {
        void Add(Alert alert);
        void Delete(Alert alert);
        Alert Get(Guid id);
        List<Alert> GetAll();
        void Save();
    }
}