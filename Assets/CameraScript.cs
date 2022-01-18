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
        //Vector3 newCamPosition = new Vector3(target.position.x - 8, transform.position.y - 3, transform.position.z );
        Vector3 newCamPosition = new Vector3(target.position.x - 11, transform.position.y, transform.position.z);
        gameObject.transform.position = newCamPosition;
    }
  }
