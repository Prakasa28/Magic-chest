using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject SensorController;
    [SerializeField]
    private GameObject pos1;
    [SerializeField]
    private GameObject pos2;
    [SerializeField]
    private GameObject pos3;
    [SerializeField]
    private GameObject pos4;
    [SerializeField]
    private GameObject pos5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        string pos = SensorController.GetComponent<SensorController>().playerPos;
        if (pos == null || pos == "")
        {
            return;
        }
        else
        {
            //Debug.Log("position: " + pos);
            switch (pos)
            {
                case "0":
                    //transform.position = pos3.transform.position;
                    break;
                case "1":
                    transform.position = pos1.transform.position;
                    break;
                case "2":
                    transform.position = pos2.transform.position;
                    break;
                case "3":
                    transform.position = pos3.transform.position;
                    break;
                case "4":
                    transform.position = pos4.transform.position;
                    break;
                case "5":
                    transform.position = pos5.transform.position;
                    break;
                default:
                    //transform.position = pos3.transform.position;
                    break;
            }
        }
    }
}
