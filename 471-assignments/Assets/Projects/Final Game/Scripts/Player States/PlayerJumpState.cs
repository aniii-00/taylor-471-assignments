using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("I'm jumping!");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        //What are we doing during this state?
        player.MovePlayer(player.default_speed);

        //On what conditions do we leave the state?
        if (player.movement.magnitude < 0.1)
        {
            player.SwitchState(player.idleState);
        }else if (player.isSneaking)
        {
            player.SwitchState(player.sneakState);
        }else if (player.isRunning == false);
        {
            player.SwitchState(player.walkState);
        }
    }
}
