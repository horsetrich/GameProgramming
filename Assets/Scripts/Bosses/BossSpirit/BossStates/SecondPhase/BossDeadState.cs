using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeadState : BspiritState
{
    public BossDeadState(BossSpirit bossSpirit, BspiritStateMachine stateMachine, BossSpiritData bossData, string animBoolName) : base(bossSpirit, stateMachine, bossData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        bossSpirit.Reward();
        
    }

    public override void Exit()
    {
        base.Exit();
        bossSpirit.SelfDestruct();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAnimationFinished)
        {
            bossSpirit.SelfDestruct();
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
