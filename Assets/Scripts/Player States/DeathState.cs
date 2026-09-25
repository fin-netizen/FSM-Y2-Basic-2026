using UnityEngine;

public class DeathState : State
{




    public DeathState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }



    public override void Enter()
    {
        base.Enter();
        Debug.Log("entering death state");
    }

    public override void Exit()
    {
        base.Exit();
    }
    // Update is called once per frame
    public override  void Update()
    {
        ReadInput();


        if (player.interactAction.IsPressed())
        {
            sm.ChangeState(sm.idleState);
        }
        if (player.jumpAction.IsPressed())
        {
            sm.ChangeState(sm.jumpState);
        }
        if (player.attackAction.IsPressed())
        {
            sm.ChangeState(sm.attackState);
        }
        if (player.moveAction.ReadValue<Vector2>().magnitude > 0.1f)
        {
            sm.ChangeState(sm.runState);
        }
        UIscript.ui.DrawText("*** This is the death state ***\n");
        UIscript.ui.DrawText("Space = Jump State");
        UIscript.ui.DrawText("E = Idle State");
        UIscript.ui.DrawText("Left/Right arrows = Move State");
        UIscript.ui.DrawText("C = Start the coroutine");
        UIscript.ui.DrawText("F = Attacking State");
    }
}
