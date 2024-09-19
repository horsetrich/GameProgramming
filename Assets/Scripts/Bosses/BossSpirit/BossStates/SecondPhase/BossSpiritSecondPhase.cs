using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpiritSecondPhase : BspiritState
{
    public BossSpiritSecondPhase(BossSpirit bossSpirit, BspiritStateMachine stateMachine, BossSpiritData bossData, string animBoolName) : base(bossSpirit, stateMachine, bossData, animBoolName)
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
        bossSpirit.StartCoroutine(bossSpirit.ScaleOverTime(5f, 32f));
        if(isAnimationFinished && bossSpirit.counter > 5)
        {
            stateMachine.ChangeState(bossSpirit.BossSpiritAttack);
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
