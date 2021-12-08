using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public GameObject player;
    private GameObject obstacle;

    public void Start()
    {
        obstacle = GameObject.FindWithTag("Obstacles");
    }

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("collided" + other);
    }
}