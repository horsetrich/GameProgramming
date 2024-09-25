using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpiritSkill : BspiritState
{
    private bool gotYou;
    public BossSpiritSkill(BossSpirit bossSpirit, BspiritStateMachine stateMachine, BossSpiritData bossData, string animBoolName) : base(bossSpirit, stateMachine, bossData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        gotYou = bossSpirit.CheckRange();
    }

    public override void Enter()
    {
        base.Enter();
        bossSpirit.counter = Time.deltaTime;
        bossSpirit.SetVelocityZero();
        bossSpirit.teleState = true;
        bossSpirit.teleport = 0;
    }

    public override void Exit()
    {
        base.Exit();
        bossSpirit.stop = false;
        bossSpirit.teleport = 0;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (bossSpirit.counter > 3 && bossSpirit.counter < 6)
        {
            bossSpirit.TeleportOne();
            bossSpirit.teleport++;
        }
        else if (bossSpirit.counter > 7 && bossSpirit.counter < 10)
        {
            bossSpirit.TeleportTwo();
            bossSpirit.teleport++;
        }
        else if (bossSpirit.counter > 11 && bossSpirit.counter < 15)
        {
            bossSpirit.TeleportThree();
            bossSpirit.stop = true;
        }
        else if(bossSpirit.counter > 17)
        {
            bossSpirit.TeleportPlayer();
            bossSpirit.telePlay = true;
        }

        if(bossSpirit.counter > 20 && bossSpirit.telePlay)
        {
            stateMachine.ChangeState(bossSpirit.BossSpiritIdle);
            bossSpirit.telePlay = false;
            bossSpirit.teleState = false;
        }
        else if (gotYou)
        {
            stateMachine.ChangeState(bossSpirit.BossSpiritAttack);
            bossSpirit.teleState = false;
            bossSpirit.chaseState = true;
            bossSpirit.counter = 0;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
