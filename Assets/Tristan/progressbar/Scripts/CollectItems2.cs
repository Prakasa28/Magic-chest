using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems2 : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        CollectableControl2.scoreCount += 1;
        this.gameObject.SetActive(false);
    }
}
