using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{

    public Rigidbody rb;

    public float forward_force;
    public float gravity;
    public float vertical_force;

    public bool grav = true;

    private void Start()
    {
        rb.velocity = Vector3.zero;
    }

    private void FixedUpdate()
    {

        rb.AddForce(0, 0, forward_force * Time.deltaTime);
        if (grav)
        {

            rb.AddForce(gravity * Time.deltaTime, -0.078f, 0);

        }

        if (Input.GetKey("w") || Input.GetKey("up"))
        {

            rb.AddForce(0, vertical_force * Time.deltaTime, 0, ForceMode.VelocityChange);

        }

        if (Input.GetKey("s") || Input.GetKey("down"))
        {

            rb.AddForce(0, -vertical_force * Time.deltaTime, 0, ForceMode.VelocityChange);

        }

        if (rb.position.x > 15.5f)
        {

            FindObjectOfType<GameManger>().EndGame();

        }

    }

    public void Cheat()
    {

        transform.position = transform.position + new Vector3(-2, 0, 0);
        grav = false;

    }

}
