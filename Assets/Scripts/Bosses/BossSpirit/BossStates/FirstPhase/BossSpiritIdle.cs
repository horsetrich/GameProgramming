using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpiritIdle : BspiritState
{
    private bool canAttack;

    public BossSpiritIdle(BossSpirit bossSpirit, BspiritStateMachine stateMachine, BossSpiritData bossData, string animBoolName) : base(bossSpirit, stateMachine, bossData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        canAttack = bossSpirit.CheckRange();
    }

    public override void Enter()
    {
        base.Enter();
        bossSpirit.counter += Time.deltaTime;
    }

    public override void Exit()
    {
        base.Exit();
        bossSpirit.counter = 0;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(bossSpirit.counter > 10)
        {
            stateMachine.ChangeState(bossSpirit.BossSpiritSummon);
        }
        else if (canAttack)
        {
            stateMachine.ChangeState(bossSpirit.BossSpiritAttack);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
