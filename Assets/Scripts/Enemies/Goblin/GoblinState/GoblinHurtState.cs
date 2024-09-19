using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinHurtState : GoblinGroundedState
{
    public GoblinHurtState(Goblin goblin, GoblinStateMachine stateMachine, GoblinData goblindata, string animBoolName) : base(goblin, stateMachine, goblindata, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        goblin.gotHurt = false;
        goblin.counter += Time.deltaTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (goblin.counter > 1)
        {
            stateMachine.ChangeState(goblin.GoblinChaseState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
