using MotionSensor.Domain.Helpers;

namespace MotionSensor.Domain
{
    public class RFIDMotionSensor
    {
        public Guid Id { get; private set; }
        public string Address { get; private set; }
        public List<Alert> AlertsList { get; private set; }

        public static Result<RFIDMotionSensor> Create(string address)
        {
            if(address == null)
            {
                return Result<RFIDMotionSensor>.Failure("Address cannot be null");
            }

            var motionSensor = new RFIDMotionSensor
            {
                Id = Guid.NewGuid(),
                Address = address,
                AlertsList = new List<Alert>()
            };

            return Result<RFIDMotionSensor>.Success(motionSensor);
        }
        
        public void AddAlert(Alert alert)
        {
            AlertsList.Add(alert);
        }
    }
}
