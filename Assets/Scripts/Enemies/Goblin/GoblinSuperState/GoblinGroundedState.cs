using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinGroundedState : GoblinState
{

    public GoblinGroundedState(Goblin goblin, GoblinStateMachine stateMachine, GoblinData goblindata, string animBoolName) : base(goblin, stateMachine, goblindata, animBoolName)
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
