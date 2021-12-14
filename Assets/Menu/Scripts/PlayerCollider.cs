using System;
using TMPro;
using UnityEngine;


namespace Menu.Scripts
{
    public class PlayerCollider : MonoBehaviour
    {
        private int damage = -1;
        public GameObject[] hearts;
        private bool isDead;
        private bool isHit;
        private String lostGameText = "You lost!";
        public TextMeshProUGUI lostGameDisplay;
        private float countdownTime = 5;

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Obstacles") && !isHit)
            {
                Debug.Log("Collided with: " + other);
                isHit = true;
                damage++;
                TakeDamage(damage);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            isHit = false;
        }


        public void Update()
        {
            DisplayMessage();
        }

        private void TakeDamage(int d)
        {
            if (d == 2)
            {
                isDead = true;
            }

            Destroy(hearts[d].gameObject);
        }

        private void DisplayMessage()
        {
            if (isDead)
            {
                countdownTime -= Time.deltaTime;
                GetComponent<PlayerDemoMovementController>().canMove = false;
                lostGameDisplay.text = lostGameText;
                Debug.Log(countdownTime);
                if (countdownTime < 0)
                {
                    Application.Quit();
                }
            }
        }
    }
}