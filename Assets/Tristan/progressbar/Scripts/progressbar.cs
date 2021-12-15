using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressbar : MonoBehaviour
{
    [SerializeField] private GameObject LevelControl;
    [SerializeField] private GameObject Player;
    [SerializeField] private Image fillImage;
    private float totalLength;
    private float playerxPos;
    // Start is called before the first frame update
    void Start()
    {
        //total level length is the length of one section times the amount of sections
        totalLength = LevelControl.GetComponent<GenerateLevel2>().xPos * (LevelControl.GetComponent<GenerateLevel2>().levelLength + 1);
    }

    // Update is called once per frame
    void Update()
    {
        //adding 10 to player position because the map starts at -10
        playerxPos = Player.transform.position.x + 10;
        //progress is player's position divided by the total map length
        fillImage.fillAmount = playerxPos/totalLength;
    }
}
