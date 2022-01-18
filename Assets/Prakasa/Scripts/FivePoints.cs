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
    private bool textShowed = false;
    private float collapsed;
    public float elapsed;
    
    void OnTriggerEnter(Collider other)
    {

        collapsed += 10;
        foodFx.Play();
        CollectableControl.scoreCount += 5;
        //this.gameObject.SetActive(false);
        StartCoroutine(ShowPoints());
    }

    private IEnumerator ShowPoints()
    {
        textShowed = true;
        //make the text visible
        fivePointsText.text = fivePoints.ToString();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        //gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        //make the text invinsible
        fivePointsText.text = "";
        textShowed = false;
        yield return null;


    }






}
