using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : PlayerGroundedState
{
    public PlayerLandState(Player player, PlayerStateMachine stateMachine, PlayerData playerdata, string animBoolName) : base(player, stateMachine, playerdata, animBoolName)
    {
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
            else if (isAnimationFinished)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            else if (Attack)
            {
                player.InputHandler.UseAttackInput();
                stateMachine.ChangeState(player.AttackState1);
            }
        }
        
    }
}
