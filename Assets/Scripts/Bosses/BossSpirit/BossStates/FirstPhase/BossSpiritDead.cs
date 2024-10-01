using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpiritDead : BspiritState
{
    public BossSpiritDead(BossSpirit bossSpirit, BspiritStateMachine stateMachine, BossSpiritData bossData, string animBoolName) : base(bossSpirit, stateMachine, bossData, animBoolName)
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
        if (bossSpirit.secondPhase && isAnimationFinished)
        {
            stateMachine.ChangeState(bossSpirit.BossSpiritSecondPhase);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
