using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPoints : MonoBehaviour
{
    public AudioSource foodFx;

    void OnTriggerEnter(Collider other)
    {
        foodFx.Play();
        CollectableControl.scoreCount += 2;
        this.gameObject.SetActive(false);
    }
}
