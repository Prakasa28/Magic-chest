using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensorController : MonoBehaviour
{

    private SerialController2 serialController2;
    public string message;
    string sensor1;
    string sensor2;
    string sensor3;
    public string playerPos;
    public string playerDis;
    [SerializeField] Image S1bar;
    [SerializeField] Image S2bar;
    [SerializeField] Image S3bar;
    [SerializeField] Image Minbar;
    [SerializeField] Image Posbar;
    [SerializeField] Image MessageIndicator;
    [SerializeField] int maxDistance = 83;
    [SerializeField] int posAmount = 5;

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
            sensor1 = inputlist[0];
            sensor2 = inputlist[1];
            sensor3 = inputlist[2];
            playerPos = inputlist[3];
            playerDis = inputlist[4];
            StartCoroutine(blinkMessageIndicator());
            S1bar.fillAmount = float.Parse(sensor1) / maxDistance;
            S2bar.fillAmount = float.Parse(sensor2) / maxDistance;
            S3bar.fillAmount = float.Parse(sensor3) / maxDistance;
            Minbar.fillAmount = float.Parse(playerDis) / maxDistance;
            Posbar.fillAmount = float.Parse(playerPos) / posAmount;
            Debug.Log("S1: " + sensor1 + " S2: " + sensor2 + " S3: " + sensor3 + " Pos: " + playerPos + " Dis: " + playerDis);

        }
        catch (System.IndexOutOfRangeException e)
        {
            Debug.LogError("invalid data lol. Probably haven't received any data yet. Error: " + e);
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
        MessageIndicator.color = Color.white;
    }
}
