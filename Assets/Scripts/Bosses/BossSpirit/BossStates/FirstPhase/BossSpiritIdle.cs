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
        bossSpirit.CheckIfShouldFlip();
    }

    public override void Enter()
    {
        base.Enter();
        bossSpirit.chaseState = true;
        bossSpirit.teleState = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        bossSpirit.GetPlayer();
        if(bossSpirit.counter > 10)
        {
            stateMachine.ChangeState(bossSpirit.BossSpiritSummon);
            bossSpirit.counter = 0;
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
