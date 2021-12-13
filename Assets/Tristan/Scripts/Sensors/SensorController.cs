using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorController : MonoBehaviour
{

    private SerialController2 serialController2;
    public string message;

    [SerializeField]
    private GameObject pos1;
    [SerializeField]
    private GameObject pos2;
    [SerializeField]
    private GameObject pos3;
    [SerializeField]
    private GameObject pos4;
    [SerializeField]
    private GameObject pos5;
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
            return;

        // Check if the message is plain data or a connect/disconnect event.
        if (ReferenceEquals(message, SerialController2.SERIAL_DEVICE_CONNECTED))
            Debug.Log("Connection established");
        else if (ReferenceEquals(message, SerialController2.SERIAL_DEVICE_DISCONNECTED))
            Debug.Log("Connection attempt failed or disconnection detected");
        else
            Debug.Log("Message arrived: " + message);
    }
}
