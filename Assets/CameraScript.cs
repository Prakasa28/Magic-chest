using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
        //Assign your ball in the inspector
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        //Here i assumed that you want to change the X 
        Vector3 newCamPosition = new Vector3(transform.position.x, transform.position.y, target.position.z - 26);
        gameObject.transform.position = newCamPosition;
    }
  }
