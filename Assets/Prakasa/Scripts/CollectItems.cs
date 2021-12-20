using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
    public AudioSource foodFx;

    void OnTriggerEnter(Collider other)
    {
        foodFx.Play();
        CollectableControl.scoreCount += 1;
        this.gameObject.SetActive(false);
    }
}
