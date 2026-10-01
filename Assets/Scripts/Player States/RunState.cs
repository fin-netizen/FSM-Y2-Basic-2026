
//This is a derived class of State
//This means it inherits fields and methods from State.cs

using UnityEngine;

public class RunState : State
{
    protected float speed;
    protected float rotationSpeed;

    public RunState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        speed = 3;
        base.Enter();
        horizontalInput = verticalInput = 0.0f;

        Debug.Log("entering running state");
        player.anim.SetBool("walk", true);
    }

    public override void Exit()
    {
        base.Exit();
        player.anim.SetBool("walk", false);
    }



    public override void Update()
    {

        
        ReadInput();
        if(player.rb.linearVelocityX <= 0 && isFacingRight == false)
        {
            Flip();
        }
        if (player.rb.linearVelocityX >= 0 && isFacingRight == true)
        {
            Flip();
        }
        if (player.moveAction.ReadValue<Vector2>().magnitude <= 0.1f)
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
        if (player.attackAction.IsPressed())
        {
            sm.ChangeState(sm.attackState);
        }
        if (player.rb.linearVelocityY <= -12)
        {
            player.anim.SetBool("dying", true);
            sm.ChangeState(sm.deathState);
        }
        //debug move gameObject
        player.rb.linearVelocityX = player.moveAction.ReadValue<Vector2>().x * speed;




    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collided in runstate");

        if( collision.tag == "enemy")
        {
            collision.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        }
    }
    public override void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exit collision in runstate");

        if (collision.tag == "enemy")
        {
            collision.GetComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f);
        }
    }



    public override void FixedUpdate()
    {
    }
}
