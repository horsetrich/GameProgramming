using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState3 : SuperAttackState
{
    public AttackState3(Player player, PlayerStateMachine stateMachine, PlayerData playerdata, string animBoolName) : base(player, stateMachine, playerdata, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        playerData.numberOfAttacks = 0;
    }

    public override void Exit()
    {
        base.Exit();


    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        //player.AttackEnemy();
        if (isAnimationFinished)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        else if(xInput != 0)
        {
            stateMachine.ChangeState(player.MoveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
