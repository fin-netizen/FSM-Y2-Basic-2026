using UnityEngine;
using System.Collections;

public class AttackState : State
{

    public AttackState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("entering attacking state");
        player.sr.color = new Color(0.8f, 0.7f, 0.1f);
    }

    public override void Exit()
    {
        base.Exit();
    }


    // Update is called once per frame
    public override void Update()
    {
        TestMethod("hello");

        ReadInput();

        if (player.interactAction.IsPressed())
        {
            sm.ChangeState(sm.idleState);
        }
        if (player.jumpAction.IsPressed())
        {
            sm.ChangeState(sm.jumpState);
        }
        if (player.deathAction.IsPressed())
        {
            sm.ChangeState(sm.deathState);
        }
        if (player.moveAction.ReadValue<Vector2>().magnitude > 0.1f)
        {
            sm.ChangeState(sm.runState);
        }

        UIscript.ui.DrawText("*** This is the attacking state ***\n");
        UIscript.ui.DrawText("Space = Jump State");
        UIscript.ui.DrawText("E = Idle State");
        UIscript.ui.DrawText("Left/Right arrows = Move State");
        UIscript.ui.DrawText("C = Start the coroutine");
        UIscript.ui.DrawText("Q = Death State");

    }
}
