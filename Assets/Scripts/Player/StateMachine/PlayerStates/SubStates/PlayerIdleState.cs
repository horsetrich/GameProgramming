using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerdata, string animBoolName) : base(player, stateMachine, playerdata, animBoolName)
    {
    }
    
    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityX(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!isExitingState)
        {
            if (xInput != 0)
            {
                stateMachine.ChangeState(player.MoveState);
            }
            else if (yInput == -1)
            {
                stateMachine.ChangeState(player.CrouchIdleState);
            }
            else if (Defended)
            {
                player.InputHandler.UseDefendInput();
                stateMachine.ChangeState(player.DefendState);
            }
            else if (Attack)
            {
                player.InputHandler.UseAttackInput();
                stateMachine.ChangeState(player.attackState1);
            }


        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
