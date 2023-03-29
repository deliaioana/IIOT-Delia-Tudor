using MotionSensor.Domain.Helpers;

namespace MotionSensor.Domain
{
    public class Alert
    {
        public Guid Id { get; private set; }
        public RFIDMotionSensor ParentMotionSensor { get; private set; }
        public DateTime TimeStamp { get; private set; }

        public static Result<Alert> Create(RFIDMotionSensor parentMotionSensor)
        {
            if (parentMotionSensor == null)
            {
                return Result<Alert>.Failure("Parent Motion Sensor cannot be null");
            }

            var alert = new Alert
            {
                Id = Guid.NewGuid(),
                ParentMotionSensor = parentMotionSensor,
                TimeStamp = DateTime.Now,
            };

            return Result<Alert>.Success(alert);
        }
    }
}
