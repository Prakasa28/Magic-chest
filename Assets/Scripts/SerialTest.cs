using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialTest : MonoBehaviour
{

    public SerialController serialController;
    public string message;

    // Start is called before the first frame update
    void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        message = serialController.ReadSerialMessage();
        
        if (message == null)
            return;

        // Check if the message is plain data or a connect/disconnect event.
        if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
            Debug.Log("Connection established");
        else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
            Debug.Log("Connection attempt failed or disconnection detected");
        //else
            //Debug.Log("Message arrived: " + message);
    }
}
