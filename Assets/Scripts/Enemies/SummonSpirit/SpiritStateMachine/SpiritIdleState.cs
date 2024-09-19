using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritIdleState : SpiritState
{

    public SpiritIdleState(Spirit spirit, SpiritStateMachine StateMachine, SpiritData spiritData, string animBoolName) : base(spirit, StateMachine, spiritData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        Spirit.counter += Time.deltaTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Spirit.GetPlayer();
        if(Spirit.counter > 7 || Spirit.isChasing)
        {
            SpiritStateMachine.ChangeState(Spirit.SpiritDieState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
