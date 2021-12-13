using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedController : MonoBehaviour
{

    [SerializeField] private SerialController serialController;
    [SerializeField] private float serialDelay = 0.008f;
    public Texture2D Animation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LedProgressBar(float progress)
    {
        progress = progress / 100 * 42;

    }
    public void LedAnimation()
    {
        StartCoroutine(doAnimation());

    }

    IEnumerator doAnimation()
    {
        List<string> frame = new List<string>();
        int frameamount = Animation.height;
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
                frame.Add((Animation.GetPixel(j, i).r * 255).ToString() + "," + (Animation.GetPixel(j, i).g * 255).ToString() + "," + (Animation.GetPixel(j, i).b * 255).ToString() + ",");
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
