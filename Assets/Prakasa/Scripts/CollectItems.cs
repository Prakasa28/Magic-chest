using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        CollectableControl.scoreCount += 1;
        this.gameObject.SetActive(false);
    }
}
