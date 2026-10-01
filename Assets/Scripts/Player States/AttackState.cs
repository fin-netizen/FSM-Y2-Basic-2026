using System.Collections;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class AttackState : State
{
    float attackTime;
    float destroyTime;
    public float testVariable;

    public AttackState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("entering attacking state");

        //start your attack animation

        player.anim.SetBool("attack", true);

        attackTime = 0.5f;
        destroyTime = 0.25f;
        //instantiate a weapon prefab
        player.SpawnWeapon();




    }

    public override void Exit()
    {
        base.Exit();

        //do stuff to stop the animation
        player.anim.SetBool("attack", false);
    }


    // Update is called once per frame
    public override void Update()
    {
      
        ReadInput();

        //check for the attack finishing
        attackTime -= Time.deltaTime;
        destroyTime -= Time.deltaTime;
        
        if (destroyTime < 0)
        {
            Object.Destroy(player.weapon);
            destroyTime = 0.5f;
            
        }
        if (attackTime < 0)
        {
            sm.ChangeState(sm.idleState);
        }
    }
}
