using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private GameObject LevelControl;
    [SerializeField] private GameObject Player;
    [SerializeField] private Image fillImage;
    public float totalTime = 0f;
    private float elapsedTime = 0f;

    // Update is called once per frame
    void Update()
    {
        //only count if the player is moving (so not during the countdown to start lol)
        if (Player.GetComponent<PlayerDemoMovementController>().canMove)
        {
            elapsedTime += Time.deltaTime;
        }

        if (elapsedTime > totalTime)
        {
            // stop the player from moving when time finishes
            Player.GetComponent<PlayerDemoMovementController>().canMove = false;
        }

        //progress is the elapsed time divided by the total amount of time the map should take
        fillImage.fillAmount = elapsedTime / totalTime;
    }
}