using UnityEngine;
using System.Collections;

public class AttackState : State
{
    float attackTime;

    public AttackState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("entering attacking state");

        //start your attack animation

        player.anim.SetBool("Attack", true);

        attackTime = 3;
       
    }

    public override void Exit()
    {
        base.Exit();

        //do stuff to stop the animation
        player.anim.SetBool("Attack", false);
    }


    // Update is called once per frame
    public override void Update()
    {
      
        ReadInput();

        //check for the attack finishing
        attackTime -= Time.deltaTime;

        if( attackTime < 0 )
        {
            sm.ChangeState(sm.idleState);
        }


    }
}
