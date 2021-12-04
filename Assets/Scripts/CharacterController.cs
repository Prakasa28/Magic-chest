using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject SerialTest;
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
        string input = SerialTest.GetComponent<SerialTest>().message;
        if (input == null)
        {
            return;
        }
        else
        {
            string[] inputlist = input.Split(char.Parse(","));
            string sensor1 = inputlist[0];
            string sensor2 = inputlist[1];
            string sensor3 = inputlist[2];
            string playerPos = inputlist[3];
            string playerDis = inputlist[4];
            Debug.Log("S1: " + sensor1 + " S2: " + sensor2 + " S3: " + sensor3 + " Pos: " + playerPos + " Dis: " + playerDis);
            switch (playerPos)
            {
                case "0":
                    transform.position = pos3.transform.position;
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
                    transform.position = pos3.transform.position;
                    break;
            }
        }
    }
}
