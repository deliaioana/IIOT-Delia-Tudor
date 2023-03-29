using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class MotionSensor_Script : MonoBehaviour
{
    public string id;

    public void SendAlert()
    {
        StartCoroutine(Upload());
    }

    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        using (UnityWebRequest www = UnityWebRequest.Post($"https://localhost:7241/api/MotionSensors/{id}/alert", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}
