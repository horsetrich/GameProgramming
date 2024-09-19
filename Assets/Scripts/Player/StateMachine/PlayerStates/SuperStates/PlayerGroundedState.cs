using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{

    protected int xInput;
    protected int yInput;

    protected bool isTouchingCeiling;

    private bool JumpInput;
    private bool isGrounded;
    protected bool Defended;
    protected bool Attack;
    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerdata, string animBoolName) : base(player, stateMachine, playerdata, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = player.CheckIfGrounded();
        isTouchingCeiling = player.CheckForCeiling();

    }

    public override void Enter()
    {
        base.Enter();

        player.JumpState.ResetAmountOfJumpsLeft();
        playerData.numberOfAttacks = 0;
        player.CantAttack();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormInputX;
        yInput = player.InputHandler.NormInputY;
        Defended = player.InputHandler.DefendInput;
        JumpInput = player.InputHandler.JumpInput;
        Attack = player.InputHandler.AttackInput;

        if (JumpInput && player.JumpState.CanJump())
        {
            
            stateMachine.ChangeState(player.JumpState);
        }else if (!isGrounded)
        {
            player.InAirState.StartCoyoteTime();
            stateMachine.ChangeState(player.InAirState);
        }


    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
