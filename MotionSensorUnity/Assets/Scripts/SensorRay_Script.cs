using UnityEngine;

public class SensorRay_Script : MonoBehaviour
{
    MotionSensor_Script motionSensor;

    void Start()
    {
        motionSensor = gameObject.transform.parent.GetComponent<MotionSensor_Script>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "RFID-Card")
        {
            motionSensor.SendAlert();
        }
    }

}
