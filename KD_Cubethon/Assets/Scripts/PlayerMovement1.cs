using Chapter.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{

    public Rigidbody rb;

    public float forward_force;
    public float gravity;
    public float sideway_force;

    public bool grav = true;

    private Invoker _invoker;
    private Command _Left, _Right;

    private void Start()
    {
        _invoker = FindObjectOfType<Invoker>();

        _Left = new Left(this);
        _Right = new Right(this);
    }

    private void FixedUpdate()
    {

        rb.AddForce(0, 0, forward_force * Time.deltaTime);
        if (grav)
        {

            rb.AddForce(0, -gravity * Time.deltaTime, 0);

        }

        if (Input.GetKey("d") || Input.GetKey("right"))
        {

            rb.AddForce(sideway_force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            _invoker.ExecuteCommand(_Right);

        }

        if (Input.GetKey("a") || Input.GetKey("left"))
        {

            rb.AddForce(-sideway_force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            _invoker.ExecuteCommand(_Left);

        }

        if (rb.position.y < -5f)
        {

            FindObjectOfType<GameManger>().EndGame();

        }

    }

    public void Cheat()
    {

        transform.position = transform.position + new Vector3(0, 2, 0);
        grav = false;

    }

}
