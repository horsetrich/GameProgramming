using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BossSpiritSummon : BspiritState
{
    public BossSpiritSummon(BossSpirit bossSpirit, BspiritStateMachine stateMachine, BossSpiritData bossData, string animBoolName) : base(bossSpirit, stateMachine, bossData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        bossSpirit.SummonEnemy();
        bossSpirit.chaseState = false;
        bossSpirit.counter = 0;
    }

    public override void Exit()
    {
        base.Exit();
        bossSpirit.counter = 0;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAnimationFinished && bossSpirit.secondPhase == false)
        {
            stateMachine.ChangeState(bossSpirit.BossSpiritSkill);
        }
        else if (bossSpirit.secondPhase)
        {
            stateMachine.ChangeState(bossSpirit.BossSpiritDead);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
