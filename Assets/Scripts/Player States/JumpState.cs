//This is a derived class of State
//This means it inherits fields and methods from State.cs


using Unity.VisualScripting.FullSerializer;
using UnityEditor.Tilemaps;
using UnityEngine;

public class JumpState : State
{
    float rotationSpeed;
    
    public JumpState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        Debug.Log("entering jumping state");
        player.anim.SetBool("jump", true);
        player.rb.linearVelocityY = 5;
        //change the sprite colour
    }

    public override void Exit()
    {
        //exit the jump state
        player.anim.SetBool("jump", false);
    }
    
    public override void Update()
    {
        IsGrounded();
        ReadInput();
        if (player.rb.linearVelocityX < 0 && isFacingRight == false && isGrounded == false)
        {
            Flip();
        }
        if (player.rb.linearVelocityX > 0 && isFacingRight == true && isGrounded == false)
        {
            Flip();
        }
        
        Debug.Log("grounded=" + isGrounded);
        if (isGrounded == true && player.rb.linearVelocityY <= 0 )
        {
            sm.ChangeState(sm.idleState);

        }
        if (player.deathAction.IsPressed())
        {
            sm.ChangeState(sm.deathState);
        }
        if (player.attackAction.IsPressed())
        {
            sm.ChangeState(sm.attackState);
        }
        if (player.rb.linearVelocityY <= -12)
        {
            player.anim.SetBool("dying", true);
            sm.ChangeState(sm.deathState);
        }
    }

    public override void FixedUpdate()
    {
        //Fixed Update 
    }
}
