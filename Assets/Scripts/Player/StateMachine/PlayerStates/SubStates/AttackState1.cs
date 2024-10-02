using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AttackState1 : SuperAttackState
{
    public AttackState1(Player player, PlayerStateMachine stateMachine, PlayerData playerdata, string animBoolName) : base(player, stateMachine, playerdata, animBoolName)
    {
    }


    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        playerData.numberOfAttacks++;
        StartAttackCoyote();
    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //player.AttackEnemy();
        if (!isExitingState)
        {
            if (attackInput)
            {
                player.InputHandler.UseAttackInput();
                stateMachine.ChangeState(player.AttackState2);
            }
            else if (isAnimationFinished)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            else if (xInput != 0)
            {
                stateMachine.ChangeState(player.MoveState);
            }
        }

            
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
