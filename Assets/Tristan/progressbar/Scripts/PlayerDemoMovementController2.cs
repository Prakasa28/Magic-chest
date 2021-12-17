using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDemoMovementController2 : MonoBehaviour
{

    [SerializeField]
    private GameObject SensorController;
    public List<GameObject> laneLocations;
    Rigidbody m_Rigidbody;
    Animator animator;
    public float m_Speed = 10f;
    public bool canMove = true;

    private Vector3 startingPosition;

    private int currentLocation = 1;

   int runningHash;

    void Start()
    {
        this.startingPosition = this.transform.position;
        m_Rigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        runningHash = Animator.StringToHash("IsRunning");
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove)
        {
            //set animation
             animator.SetBool(runningHash, false);

            m_Rigidbody.velocity = transform.forward * 0;
            return;
        }

        animator.SetBool(runningHash, true);
        m_Rigidbody.velocity = transform.forward * m_Speed;

        string pos = SensorController.GetComponent<SensorController>().playerPos;
        if (pos != null && pos != "")
        {
            Debug.Log("position: " + pos);
            switch (pos)
            {
                case "0":
                    //transform.position = pos3.transform.position;
                    break;
                case "1":
                    currentLocation = 0;
                    break;
                case "2":
                    break;
                case "3":
                    currentLocation = 1;
                    break;
                case "4":
                    break;
                case "5":
                    currentLocation = 2;
                    break;
                default:
                    //transform.position = pos3.transform.position;
                    break;
            }
        }


        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLocation > 0)
        {
            currentLocation--;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && currentLocation < 2)
        {
            currentLocation++;
        }


        transform.position = new Vector3(transform.position.x, transform.position.y, laneLocations[currentLocation].transform.position.z);

    }
}
