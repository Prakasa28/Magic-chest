using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialTest : MonoBehaviour
{

    private SerialController serialController;
    public string message;
    bool ledProgress = true;
    public float serialDelay = 0.006f;
    public Texture2D Animation1;

    // Start is called before the first frame update
    void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
        //InvokeRepeating("LedStuff", 2f, 0.1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //
        // Receiving
        //

        message = serialController.ReadSerialMessage();
        
        if (message == null)
            return;

        // Check if the message is plain data or a connect/disconnect event.
        if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
            Debug.Log("Connection established");
        else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
            Debug.Log("Connection attempt failed or disconnection detected");
        else
            Debug.Log("Message arrived: " + message);



        //
        // Sending
        //

        //serialController.SendSerialMessage("1,255,255,255");
    }
    public void LedStuff()
    {
        string ledsection1;
        string ledsection2;
        string ledsection3;
        string ledsection4;
        string ledsection5;
        string ledsection6;
        if (ledProgress)
        {
            ledProgress = false;
            ledsection1 = "1,255,0,0,0,255,0,0,0,255,0,255,255,255,255,0,255,0,255,255,255,255,";
            ledsection2 = "2,255,0,0,0,255,0,0,0,255,0,255,255,255,255,0,255,0,255,255,255,255,";
            ledsection3 = "3,255,0,0,0,255,0,0,0,255,0,255,255,255,255,0,255,0,255,255,255,255,";
            ledsection4 = "4,255,0,0,0,255,0,0,0,255,0,255,255,255,255,0,255,0,255,255,255,255,";
            ledsection5 = "5,255,0,0,0,255,0,0,0,255,0,255,255,255,255,0,255,0,255,255,255,255,";
            ledsection6 = "6,255,0,0,0,255,0,0,0,255,0,255,255,255,255,0,255,0,255,255,255,255,";
        }
        else
        {
            ledProgress = true;
            ledsection1 = "1,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,";
            ledsection2 = "2,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,";
            ledsection3 = "3,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,";
            ledsection4 = "4,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,";
            ledsection5 = "5,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,";
            ledsection6 = "6,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,";
        }
        StartCoroutine(SendLed(ledsection1, ledsection2, ledsection3, ledsection4, ledsection5, ledsection6));
    }

    public void LedAnimation()
    {
        StartCoroutine(doAnimation());

    }

    IEnumerator doAnimation()
    {
        List<string> frame = new List<string>();
        int frameamount = Animation1.height;
        string ledsection1;
        string ledsection2;
        string ledsection3;
        string ledsection4;
        string ledsection5;
        string ledsection6;
        for (int i = 0; i < frameamount; i++)
        {
            Debug.Log("frame: " + i);
            ledsection1 = "1,";
            ledsection2 = "2,";
            ledsection3 = "3,";
            ledsection4 = "4,";
            ledsection5 = "5,";
            ledsection6 = "6,";
            frame.Clear();
            for (int j = 0; j <= 41; j++)
            {
                frame.Add((Animation1.GetPixel(j, i).r * 255).ToString() + "," + (Animation1.GetPixel(j, i).g * 255).ToString() + "," + (Animation1.GetPixel(j, i).b * 255).ToString() + ",");
            }
            for (int j = 0; j <= 6; j++)
            {
                ledsection1 = ledsection1 + frame[j];
            }
            for (int j = 7; j <= 13; j++)
            {
                ledsection2 = ledsection2 + frame[j];
            }
            for (int j = 14; j <= 20; j++)
            {
                ledsection3 = ledsection3 + frame[j];
            }
            for (int j = 21; j <= 27; j++)
            {
                ledsection4 = ledsection4 + frame[j];
            }
            for (int j = 28; j <= 34; j++)
            {
                ledsection5 = ledsection5 + frame[j];
            }
            for (int j = 35; j <= 41; j++)
            {
                ledsection6 = ledsection6 + frame[j];
            }
            StartCoroutine(SendLed(ledsection1, ledsection2, ledsection3, ledsection4, ledsection5, ledsection6));
            yield return new WaitForSecondsRealtime(serialDelay * 7);
        }
    }


    IEnumerator SendLed(string section1, string section2, string section3, string section4, string section5, string section6)
    {
        Debug.Log(section1);
        serialController.SendSerialMessage(section1);
        yield return new WaitForSecondsRealtime(serialDelay);
        Debug.Log(section2);
        serialController.SendSerialMessage(section2);
        yield return new WaitForSecondsRealtime(serialDelay);
        Debug.Log(section3);
        serialController.SendSerialMessage(section3);
        yield return new WaitForSecondsRealtime(serialDelay);
        Debug.Log(section4);
        serialController.SendSerialMessage(section4);
        yield return new WaitForSecondsRealtime(serialDelay);
        Debug.Log(section5);
        serialController.SendSerialMessage(section5);
        yield return new WaitForSecondsRealtime(serialDelay);
        Debug.Log(section6);
        serialController.SendSerialMessage(section6);
        yield return new WaitForSecondsRealtime(serialDelay);
    }
}
