using Chapter.Observer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : Chapter.Observer.Subject
{

    public PlayerMovement1 movement1;
    public PlayerMovement2 movement2;
    public CameraBehavior cameraBehavior;

    private void Awake()
    {
        Attach(FindFirstObjectByType<HUDController>());
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Obstacle")
        {

            Debug.Log("We hit an obstacle");
            cameraBehavior.gameLost = true;
            Debug.Log(this.name);
            if (true)
            {
                movement1.NotifyObservers();
            }
            if (this.GetComponent<PlayerMovement2>())
            {
                movement2.NotifyObservers();
            }
            movement1.enabled = false;
            movement2.enabled = false;
            FindObjectOfType<GameManger>().EndGame();

        }

    }

}
