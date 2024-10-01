using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpiritAttack : BspiritState
{
    public bool stillHere;
    public BossSpiritAttack(BossSpirit bossSpirit, BspiritStateMachine stateMachine, BossSpiritData bossData, string animBoolName) : base(bossSpirit, stateMachine, bossData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        stillHere = bossSpirit.CheckRange();
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
            if (bossSpirit.teleState && !stillHere)
            {
                stateMachine.ChangeState(bossSpirit.BossSpiritSkill);
            }
            else if (bossSpirit.chaseState && !stillHere)
            {
                stateMachine.ChangeState(bossSpirit.BossSpiritIdle);
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
