using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public int counter;

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacles"))
        {
            counter++;
            if (counter == 3)
            {
            }
        }
    }
}