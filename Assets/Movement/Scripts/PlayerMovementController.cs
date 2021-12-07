using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private GameObject SerialTest;
    public List<GameObject> laneLocations;

    Rigidbody m_Rigidbody;
    float m_Speed;
    public bool canMove;

    private Vector3 startingPosition;

    void Start()
    {
        this.startingPosition = this.transform.position;
        m_Rigidbody = GetComponent<Rigidbody>();
        //Set the speed of the GameObject
        m_Speed = 10.0f;
    }


    void Update()
    {
        if (canMove)
        {
            m_Rigidbody.velocity = transform.forward * m_Speed;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        string input = SerialTest.GetComponent<SerialTest>().message;
        if (input == null || input == "-1.00" || input == "__Connected__" || input == "")
        {
            return;
        }
        if (canMove)
        {
            int index = (int) float.Parse(input);
            transform.position = new Vector3(laneLocations[index - 1].transform.position.x, transform.position.y,
                transform.position.z);
        }
    }
}