public interface Command
{
    public void Execute();
    public void replay(PlayerMovement1 controller1, PlayerMovement2 controller2);
}