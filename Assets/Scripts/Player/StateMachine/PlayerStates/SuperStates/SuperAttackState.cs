using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class SuperAttackState : PlayerState
{

    protected int xInput;
    protected int yInput;

    protected bool attackInput;
    protected bool attackCoyote;


    public SuperAttackState(Player player, PlayerStateMachine stateMachine, PlayerData playerdata, string animBoolName) : base(player, stateMachine, playerdata, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        AttackCheckCoyoteTime();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        attackInput = player.InputHandler.AttackInput;
        xInput = player.InputHandler.NormInputX;
        yInput = player.InputHandler.NormInputY;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void AttackCheckCoyoteTime()
    {
        if (attackCoyote && Time.time > startTime + playerData.coyoteTime)
        {
            attackCoyote = false;
        }
    }

    public void StartAttackCoyote() => attackCoyote = true;
}
