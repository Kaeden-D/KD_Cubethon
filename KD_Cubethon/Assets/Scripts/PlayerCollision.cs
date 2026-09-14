using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerMovement1 movement1;
    public PlayerMovement2 movement2;
    public CameraBehavior cameraBehavior;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Obstacle")
        {

            Debug.Log("We hit an obstacle");
            cameraBehavior.gameLost = true;
            movement1.enabled = false;
            movement2.enabled = false;
            FindObjectOfType<GameManger>().EndGame();

        }

    }

}
