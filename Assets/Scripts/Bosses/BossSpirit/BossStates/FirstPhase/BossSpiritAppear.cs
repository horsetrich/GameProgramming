using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpiritAppear : BspiritState
{
    public BossSpiritAppear(BossSpirit bossSpirit, BspiritStateMachine stateMachine, BossSpiritData bossData, string animBoolName) : base(bossSpirit, stateMachine, bossData, animBoolName)
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
            stateMachine.ChangeState(bossSpirit.BossSpiritIdle);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
