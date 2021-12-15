using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressbartime : MonoBehaviour
{
    [SerializeField] private GameObject LevelControl;
    [SerializeField] private GameObject Player;
    [SerializeField] private Image fillImage;
    [SerializeField] private float sectionTime;
    private float totalTime = 0f;
    private float elapsedTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //the time it takes the player to finish 1 section is the length of a section divided by the player's speed
        sectionTime = LevelControl.GetComponent<GenerateLevel2>().xPos / Player.GetComponent<PlayerDemoMovementController2>().m_Speed;
        //the total time for the map is the time of one section times the amount of sections
        totalTime = sectionTime * (LevelControl.GetComponent<GenerateLevel2>().levelLength + 1);
    }

    // Update is called once per frame
    void Update()
    {
        //only count if the player is moving (so not during the countdown to start lol)
        if (Player.GetComponent<PlayerDemoMovementController2>().canMove)
        {
            elapsedTime += Time.deltaTime;
        }
        //progress is the elapsed time divided by the total amount of time the map should take
        fillImage.fillAmount = elapsedTime / totalTime;
    }
}
