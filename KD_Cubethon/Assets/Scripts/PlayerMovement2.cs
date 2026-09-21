using Chapter.Observer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : Subject
{

    public Rigidbody rb;

    public float forward_force;
    public float gravity;
    public float vertical_force;

    public bool grav = true;

    private Invoker _invoker;
    private Command _Up, _Down;

    private void Start()
    {
        rb.velocity = Vector3.zero;

        _invoker = FindObjectOfType<Invoker>();

        _Up = new Up(this);
        _Down = new Down(this);
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
            _invoker.ExecuteCommand(_Up);

        }

        if (Input.GetKey("s") || Input.GetKey("down"))
        {

            rb.AddForce(0, -vertical_force * Time.deltaTime, 0, ForceMode.VelocityChange);
            _invoker.ExecuteCommand(_Down);

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
