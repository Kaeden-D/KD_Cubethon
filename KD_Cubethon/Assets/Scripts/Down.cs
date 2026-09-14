//using Chapter.EventBus;
using UnityEngine;

public class Down : Command
{

    private PlayerMovement2 _controller;

    public Down(PlayerMovement2 controller)
    {
        _controller = controller;
    }

    public void replay(PlayerMovement1 controller1, PlayerMovement2 controller2)
    {
        _controller = controller2;
    }

    public void Execute()
    {
        _controller.rb.AddForce(0, -_controller.vertical_force * Time.deltaTime, 0, ForceMode.VelocityChange);
    }

}