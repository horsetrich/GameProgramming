using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpiritSkill : BspiritState
{
    private bool stop = false;
    public BossSpiritSkill(BossSpirit bossSpirit, BspiritStateMachine stateMachine, BossSpiritData bossData, string animBoolName) : base(bossSpirit, stateMachine, bossData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        bossSpirit.counter = Time.deltaTime;
    }

    public override void Exit()
    {
        base.Exit();
        stop = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(bossSpirit.counter > 3 && bossSpirit.counter < 6)
        {
            bossSpirit.TeleportOne();
        }
        else if(bossSpirit.counter > 6 && bossSpirit.counter < 9)
        {
            bossSpirit.TeleportTwo();
        }
        else if(bossSpirit.counter > 9 && bossSpirit.counter < 12)
        {
            bossSpirit.TeleportThree();
            stop = true;
        }
        else if(bossSpirit.counter > 12 && stop)
        {
            bossSpirit.TeleportPlayer();
        }

        if(bossSpirit.counter > 15)
        {
            stateMachine.ChangeState(bossSpirit.BossSpiritIdle);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
