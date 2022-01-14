using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class FivePoints : MonoBehaviour
{
    public AudioSource foodFx;
    public TextMeshProUGUI fivePointsText;
    private String fivePoints = "+ 5";
    private bool isFivePointsActive = true;

    void OnTriggerEnter(Collider other)
    {
        
            foodFx.Play();
            CollectableControl.scoreCount += 5;
           // fivePointsText.text = fivePoints.ToString();
            this.gameObject.SetActive(false);
 
    }

    



}
