using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpiritStart : BspiritState
{
    private bool startFight;

    public BossSpiritStart(BossSpirit bossSpirit, BspiritStateMachine stateMachine, BossSpiritData bossData, string animBoolName) : base(bossSpirit, stateMachine, bossData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        startFight = bossSpirit.BeginFight();
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
        if (startFight)
        {
            stateMachine.ChangeState(bossSpirit.BossSpiritAppear);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
