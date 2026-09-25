
//This is a derived class of State
//This means it inherits fields and methods from State.cs

using UnityEngine;
using System.Collections;

public class IdleState : State
{
    // constructor
    public IdleState( PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        // this method is called when the state begins

        Debug.Log("entering idle state");
        player.anim.SetBool("Idle", true);
    }

    public override void Exit()
    {
        // this method is called when the state has finished
        Debug.Log("exiting idle state");
        player.anim.SetBool("Idle", false);
        //you should disable any running coroutines here
        player.StopAllCoroutines();
    }


    public override void Update()
    {
        if( player.moveAction.ReadValue<Vector2>().magnitude > 0.1f )
        {
            sm.ChangeState(sm.runState);
        }

        if (player.jumpAction.IsPressed())
        {
            sm.ChangeState(sm.jumpState);
        }
      
        if (player.attackAction.IsPressed())
        {
            sm.ChangeState(sm.attackState);
        }

     

        UIscript.ui.DrawText("*** This is the idle state ***\n");
        UIscript.ui.DrawText("Space = Jump State");
        UIscript.ui.DrawText("Left/Right arrows = Move State");
        UIscript.ui.DrawText("C = Start the coroutine");
        UIscript.ui.DrawText("Q = Death State");
        UIscript.ui.DrawText("F = Attacking State");

    }

    public override void FixedUpdate()
    {
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided");
    }


    



}
