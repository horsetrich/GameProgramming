using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAttackState : GoblinGroundedState
{
    protected bool inRange;

    public GoblinAttackState(Goblin goblin, GoblinStateMachine stateMachine, GoblinData goblindata, string animBoolName) : base(goblin, stateMachine, goblindata, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        inRange = goblin.CheckRange();
    }

    public override void Enter()
    {
        base.Enter();
        goblin.SetVelocityZero();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!inRange)
        {
            stateMachine.ChangeState(goblin.GoblinChaseState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
