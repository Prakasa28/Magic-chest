using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Scripts
{
    public class CountdownController2 : MonoBehaviour
    {
        private int countdownTime = 5;
        private String countDownText = "Start!";
        public TextMeshProUGUI countdownDisplay;
        public PlayerDemoMovementController2 playerDemoMovementController2;
        
        private void Start()
        {
            playerDemoMovementController2.canMove = false;
            StartCoroutine(CountdownToStart());
        }

        IEnumerator CountdownToStart()
        {
            while (countdownTime > 0)
            {
                countdownDisplay.text = countdownTime.ToString();
                yield return new WaitForSeconds(1f);
                countdownTime--;
            }
            countdownDisplay.text = countDownText;
            
            yield return new WaitForSeconds(1f);
            countdownDisplay.gameObject.SetActive(false);
            playerDemoMovementController2.canMove = true;
        }
        
    }
}