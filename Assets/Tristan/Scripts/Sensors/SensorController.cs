using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensorController : MonoBehaviour
{

    private SerialController2 serialController2;
    public string message;
    float sensor1;
    float sensor2;
    float sensor3;
    public int playerPos;
    public float playerDis;
    [SerializeField] Image S1bar;
    [SerializeField] Image S2bar;
    [SerializeField] Image S3bar;
    [SerializeField] Image Minbar;
    [SerializeField] Image Posbar;
    [SerializeField] Image MessageIndicator;
    [SerializeField] int maxDistance = 150;
    [SerializeField] int triggerDistance = 40;
    int posAmount = 2;

    // Start is called before the first frame update
    void Start()
    {
        serialController2 = GameObject.Find("SerialController2").GetComponent<SerialController2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        //
        // Receiving
        //

        message = serialController2.ReadSerialMessage();

        if (message == null)
        {
            return;
        }
        try
        {
            string[] inputlist = message.Split(char.Parse(","));
            sensor1 = float.Parse(inputlist[0]);
            sensor2 = float.Parse(inputlist[1]);
            sensor3 = float.Parse(inputlist[2]);
            StartCoroutine(blinkMessageIndicator());
            if (sensor1 <= triggerDistance && sensor1 < sensor2 && sensor1 < sensor3) { playerPos = 0; playerDis = sensor1; }
            else if (sensor2 <= triggerDistance && sensor2 < sensor1 && sensor2 < sensor3) { playerPos = 1; playerDis = sensor2; }
            else if (sensor3 <= triggerDistance && sensor3 < sensor1 && sensor3 < sensor2) { playerPos = 2; playerDis = sensor3; }
            S1bar.fillAmount = sensor1 / maxDistance;
            S2bar.fillAmount = sensor2 / maxDistance;
            S3bar.fillAmount = sensor3 / maxDistance;
            Minbar.fillAmount = playerDis / maxDistance;
            Posbar.fillAmount = (float)playerPos / (float)posAmount;
            if (sensor1 < triggerDistance) { S1bar.color = Color.yellow; }
            else { S1bar.color = Color.red; }
            if (sensor2 < triggerDistance) { S2bar.color = Color.yellow; }
            else { S2bar.color = Color.red; }
            if (sensor3 < triggerDistance) { S3bar.color = Color.yellow; }
            else { S3bar.color = Color.red; }

            Debug.Log("S1: " + sensor1 + " S2: " + sensor2 + " S3: " + sensor3 + " Pos: " + playerPos.ToString() + " Dis: " + playerDis);

        }
        catch (System.IndexOutOfRangeException e)
        {
            Debug.LogWarning("invalid data. Probably haven't received any data yet. Error: " + e);
        }
        catch (System.FormatException e)
        {
            Debug.LogWarning("invalid data. didn't receive parsable float. this is normal when the scene just started. Error: " + e);
        }


        // Check if the message is plain data or a connect/disconnect event.
        if (ReferenceEquals(message, SerialController2.SERIAL_DEVICE_CONNECTED))
            Debug.Log("Connection established");
        else if (ReferenceEquals(message, SerialController2.SERIAL_DEVICE_DISCONNECTED))
            Debug.Log("Connection attempt failed or disconnection detected");
        //else
            //Debug.Log("Message arrived: " + message);
    }
    IEnumerator blinkMessageIndicator()
    {
        MessageIndicator.color = Color.yellow;
        yield return new WaitForSecondsRealtime(0.1f);
        MessageIndicator.color = Color.black;
    }
}
