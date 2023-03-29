using Microsoft.EntityFrameworkCore;
using MotionSensor.Domain;

namespace MotionSensor.Application.Repositories
{
    public class AlertRepository : IAlertRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public AlertRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Add(Alert alert)
        {
            _databaseContext.Alerts.Add(alert);
        }

        public List<Alert> GetAll()
        {
            return _databaseContext.Alerts.Include(e => e.ParentMotionSensor).ToList();
        }

        public Alert Get(Guid id)
        {
            return _databaseContext.Alerts.Include(e => e.ParentMotionSensor).FirstOrDefault(e => e.Id == id);
        }

        public void Delete(Alert alert)
        {
            _databaseContext.Alerts.Remove(alert);
        }

        public void Save()
        {
            _databaseContext.Save();
        }
    }
}
