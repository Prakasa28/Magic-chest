using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableControl2 : MonoBehaviour
{
    public static int scoreCount;
    public GameObject Score;

    // Update is called once per frame
    void Update()
    {
        Score.GetComponent<Text>().text = "" + scoreCount;
    }
}
