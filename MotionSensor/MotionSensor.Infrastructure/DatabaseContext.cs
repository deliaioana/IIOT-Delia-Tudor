using Microsoft.EntityFrameworkCore;
using MotionSensor.Application;
using MotionSensor.Domain;

namespace MotionSensor.Infrastructure
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<RFIDMotionSensor> MotionSensors => Set<RFIDMotionSensor>();

        public DbSet<Alert> Alerts => Set<Alert>();

        public void Save()
        {
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = MotionSensor.db");
        }
    }
}
