using Microsoft.EntityFrameworkCore;
using MotionSensor.Domain;

namespace MotionSensor.Application
{
    public interface IDatabaseContext
    {
        public DbSet<RFIDMotionSensor> MotionSensors { get; }
        public DbSet<Alert> Alerts { get; }

        void Save();
    }
}
