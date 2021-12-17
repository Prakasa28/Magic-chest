using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private GameObject SerialTest;
    public List<GameObject> laneLocations;

    Rigidbody m_Rigidbody;
    Animator animator;
    public float m_Speed = 0;

    public bool canMove;

    private Vector3 startingPosition;

    public float startingSpeed = 10f;

    public float movementIncreaseInterval = 1;
    public float movementIncreaseAmount = 1;


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

        if (!startedIncreaseing)
        {
            StartCoroutine(IncreaseMovementSpeed());
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
            int index = (int)float.Parse(input);
            transform.position = new Vector3(laneLocations[index - 1].transform.position.x, transform.position.y,
                transform.position.z);
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