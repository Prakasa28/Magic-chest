using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDemoMovementController : MonoBehaviour
{


    public List<GameObject> laneLocations;
    Rigidbody m_Rigidbody;
    Animator animator;
    public float m_Speed = 0;
    public bool canMove = true;

    public float startingSpeed = 10f;

    public float movementIncreaseInterval = 1.5f;
    public float movementIncreaseAmount = 1f;

    private Vector3 startingPosition;

    private int currentLocation = 1;

    int runningHash;

    bool startedIncreaseing = false;

    void Start()
    {
        this.startingPosition = this.transform.position;
        m_Rigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        runningHash = Animator.StringToHash("IsRunning");
        m_Speed = startingSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove)
        {
            //set animation
            animator.SetBool(runningHash, false);

            m_Rigidbody.velocity = transform.forward * 0;
            m_Speed = startingSpeed;
            return;
        }

        animator.SetBool(runningHash, true);
        m_Rigidbody.velocity = transform.forward * m_Speed;

        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLocation > 0)
        {
            currentLocation--;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && currentLocation < 2)
        {
            currentLocation++;
        }


        transform.position = new Vector3(transform.position.x, transform.position.y, laneLocations[currentLocation].transform.position.z);

        if (!startedIncreaseing)
        {
            StartCoroutine(IncreaseMovementSpeed());
        }
    }

    IEnumerator IncreaseMovementSpeed()
    {
        startedIncreaseing = true;
        for (; ; )
        {
            m_Speed += movementIncreaseAmount;
            // execute block of code here
            yield return new WaitForSeconds(movementIncreaseInterval);
        }
    }

    public void resetMovementSpeed()
    {
        m_Speed = startingSpeed;
    }


}
