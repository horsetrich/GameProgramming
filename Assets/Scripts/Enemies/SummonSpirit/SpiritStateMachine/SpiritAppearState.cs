using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritAppearState : SpiritState
{
    public SpiritAppearState(Spirit spirit, SpiritStateMachine StateMachine, SpiritData spiritData, string animBoolName) : base(spirit, StateMachine, spiritData, animBoolName)
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
        if (!isExitingState)
        {
            if (isAnimationFinished || Spirit.counter > 2)
            {
                SpiritStateMachine.ChangeState(Spirit.SpiritIdleState);
            }
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
