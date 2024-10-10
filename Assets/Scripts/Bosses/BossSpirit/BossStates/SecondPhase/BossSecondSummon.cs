using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSecondSummon : BspiritState
{
    public BossSecondSummon(BossSpirit bossSpirit, BspiritStateMachine stateMachine, BossSpiritData bossData, string animBoolName) : base(bossSpirit, stateMachine, bossData, animBoolName)
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
        if (isAnimationFinished)
        {
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
