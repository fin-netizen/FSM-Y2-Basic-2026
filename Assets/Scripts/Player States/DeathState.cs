using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class DeathState : State
{
    float deathTime;




    public DeathState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }



    public override void Enter()
    {
        base.Enter();
        player.anim.SetBool("dying", true);
        deathTime = 3;
    }

    public override void Exit()
    {
        base.Exit();
        player.anim.SetBool("dying", false);
    }
    // Update is called once per frame
    public override  void Update()
    {
        ReadInput();
        deathTime -= Time.deltaTime;
        if(deathTime < 0)
        {
            player.RespawnPlayer();
            deathTime = 3;
        }

    }

}
