using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XInput;
using UnityEngine.Windows;

public class PlayerDefendState : PlayerState
{

    private int xInput;
    private int yInput;
    private bool isGrounded;
    private bool jumpInput;

    public PlayerDefendState(Player player, PlayerStateMachine stateMachine, PlayerData playerdata, string animBoolName) : base(player, stateMachine, playerdata, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();


    }

    public override void Enter()
    {
        base.Enter();

        player.MakeInvincible();
    }

    public override void Exit()
    {
        base.Exit();
        player.MakeVincible();
        playerData.timesDefended = 1;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        xInput = player.InputHandler.NormInputX;
        yInput = player.InputHandler.NormInputY;

            if (isAnimationFinished && xInput == 0)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            else if (xInput != 0)
            {
                stateMachine.ChangeState(player.MoveState);
            }
        


        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }


}
