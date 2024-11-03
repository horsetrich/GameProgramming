using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpiritFloor : BspiritState
{
    public BossSpiritFloor(BossSpirit bossSpirit, BspiritStateMachine stateMachine, BossSpiritData bossData, string animBoolName) : base(bossSpirit, stateMachine, bossData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        bossSpirit.counter = 0;
        bossSpirit.MakeThing();
    }

    public override void Exit()
    {
        base.Exit();
        bossSpirit.counter = 0;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (bossSpirit.counter > 6)
        {
            stateMachine.ChangeState(bossSpirit.BossSpiritHurt);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
