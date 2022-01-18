using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedController : MonoBehaviour
{

    [SerializeField] private SerialController serialController;
    [SerializeField] private float serialDelay = 0.01f;
    public Texture2D Animation;
    List<string> frame = new List<string>();
    List<string> previousframe = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
    }

    private void FixedUpdate()
    {

    }

    public void LedPosition(float position)//, float width)
    {
        frame.Clear();
        int posint = (int)position;
        for (int i = 0; i <= 41; i++){
            if (i == posint)
            {
                frame.Add("255,255,255,");
            }
            else
            {
                frame.Add("0,0,0,");
            }
        }
        ShowFrame(frame);
    }


    public void LedAnimation()
    {
        StartCoroutine(doAnimation());
    }

    IEnumerator doAnimation()
    {
        frame.Clear();
        int frameamount = Animation.height;
        for (int i = 0; i < frameamount; i++)
        {
            Debug.Log("frame: " + i);
            frame.Clear();
            for (int j = 0; j <= 41; j++)
            {
                frame.Add((Animation.GetPixel(j, i).r * 255).ToString() + "," + (Animation.GetPixel(j, i).g * 255).ToString() + "," + (Animation.GetPixel(j, i).b * 255).ToString() + ",");
            }
            ShowFrame(frame);
            yield return new WaitForSecondsRealtime(serialDelay * 7);
        }
    }

    void ShowFrame(List<string> frame)
    {
        string ledsection1 = "1,";
        string ledsection2 = "2,";
        string ledsection3 = "3,";
        string ledsection4 = "4,";
        string ledsection5 = "5,";
        string ledsection6 = "6,";
        for (int i = 0; i <= 6; i++)
        {
            ledsection1 = ledsection1 + frame[i];
        }
        for (int i = 7; i <= 13; i++)
        {
            ledsection2 = ledsection2 + frame[i];
        }
        for (int i = 14; i <= 20; i++)
        {
            ledsection3 = ledsection3 + frame[i];
        }
        for (int i = 21; i <= 27; i++)
        {
            ledsection4 = ledsection4 + frame[i];
        }
        for (int i = 28; i <= 34; i++)
        {
            ledsection5 = ledsection5 + frame[i];
        }
        for (int i = 35; i <= 41; i++)
        {
            ledsection6 = ledsection6 + frame[i];
        }
        StartCoroutine(SendLed(ledsection1, ledsection2, ledsection3, ledsection4, ledsection5, ledsection6));
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
