//using Chapter.EventBus;
using UnityEngine;

public class Left : Command
{

    private PlayerMovement1 _controller;

    public Left(PlayerMovement1 controller)
    {
        _controller = controller;
    }

    public void replay(PlayerMovement1 controller1, PlayerMovement2 controller2)
    {
        _controller = controller1;
    }

    public void Execute()
    {
        _controller.rb.AddForce(-_controller.sideway_force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

}