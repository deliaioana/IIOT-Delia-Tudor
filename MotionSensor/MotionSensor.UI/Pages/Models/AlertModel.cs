namespace MotionSensor.UI.Pages.Models
{
    public class AlertModel
    {
        public Guid Id { get; set; }
        public RFIDMotionSensorModel ParentMotionSensor { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
