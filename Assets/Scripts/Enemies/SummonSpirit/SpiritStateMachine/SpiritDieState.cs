using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritDieState : SpiritState
{
    public SpiritDieState(Spirit spirit, SpiritStateMachine StateMachine, SpiritData spiritData, string animBoolName) : base(spirit, StateMachine, spiritData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
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
        if (isAnimationFinished)
        {
            Spirit.SpiritDie();
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
