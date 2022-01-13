using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private Image fillImage;
    [SerializeField] private GameObject hat1;
    [SerializeField] private GameObject hat2;
    [SerializeField] private GameObject hat3;
    [SerializeField] private GameObject hat4;
    [SerializeField] private GameObject hat5;
    [SerializeField] private GameObject ScoreCount;
    private int finalScore;
    public GameObject score;
    public GameObject winGameText;
    public float totalTime = 0f;
    private float elapsedTime = 0f;
    [SerializeField] private LedController ledController;

    private string winningText = "You win!";

    // Update is called once per frame
    void Update()
    {
        //only count if the player is moving (so not during the countdown to start lol)
        if (Player.GetComponent<PlayerMovementController>().canMove)
        {
            elapsedTime += Time.deltaTime;
        }

        //stuff to do when the level ends
        if (elapsedTime > totalTime)
        {
            // stop the player from moving when time finishes
            Player.GetComponent<PlayerMovementController>().canMove = false;
            // turn off the progress bar
            gameObject.SetActive(false);
            // display winning text
            winGameText.GetComponent<TextMeshProUGUI>().text = winningText;
            Vector3 pos = new Vector3(0, -90, 0);
            score.GetComponent<RectTransform>().position = winGameText.GetComponent<RectTransform>().position + pos;
            //check score and apply hat
            finalScore = int.Parse(ScoreCount.GetComponent<UnityEngine.UI.Text>().text);
            if (finalScore < 20)
            {
                hat1.SetActive(true);
            }
            else if(finalScore >= 20 && finalScore < 40)
            {
                hat2.SetActive(true);
            }
            else if (finalScore >= 40 && finalScore < 60)
            {
                hat3.SetActive(true);
            }
            else if (finalScore >= 60 && finalScore < 75)
            {
                hat4.SetActive(true);
            }
            else if (finalScore >= 75)
            {
                hat5.SetActive(true);
            }
            Debug.Log("Final score: " + finalScore);
            //play led animation
            ledController.LedAnimation();
        }

        //progress is the elapsed time divided by the total amount of time the map should take
        fillImage.fillAmount = elapsedTime / totalTime;
    }
}