using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Scripts
{
    public class CountdownController : MonoBehaviour
    {
        private int countdownTime = 5;
        private String countDownText = "Start!";
        public TextMeshProUGUI countdownDisplay;
        public PlayerMovementController playerMovementController;
        private void Start()
        {
            StartCoroutine(CountdownToStart());
        }

        IEnumerator CountdownToStart()
        {
            while (countdownTime > 0)
            {
                countdownDisplay.text = countdownTime.ToString();
                yield return new WaitForSeconds(1f);
                countdownTime--;
                playerMovementController.canMove = false;
            }
            countdownDisplay.text = countDownText;
            yield return new WaitForSeconds(1f);
            countdownDisplay.gameObject.SetActive(false);
            playerMovementController.canMove = true;
        }
        
    }
}