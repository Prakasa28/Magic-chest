using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorController : MonoBehaviour
{

    private SerialController2 serialController2;
    public string message;
    string sensor1;
    string sensor2;
    string sensor3;
    public string playerPos;
    public string playerDis;

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
        }
        catch(System.IndexOutOfRangeException e)
        {
            Debug.LogError("invalid data lol. Probably haven't received any data yet. Error: " + e);
        }

        //Debug.Log("S1: " + sensor1 + " S2: " + sensor2 + " S3: " + sensor3 + " Pos: " + playerPos + " Dis: " + playerDis);

        // Check if the message is plain data or a connect/disconnect event.
        if (ReferenceEquals(message, SerialController2.SERIAL_DEVICE_CONNECTED))
            Debug.Log("Connection established");
        else if (ReferenceEquals(message, SerialController2.SERIAL_DEVICE_DISCONNECTED))
            Debug.Log("Connection attempt failed or disconnection detected");
        else
            Debug.Log("Message arrived: " + message);
    }
}
