using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinPatrol : GoblinGroundedState
{
    public bool foundYou;
    public GoblinPatrol(Goblin goblin, GoblinStateMachine stateMachine, GoblinData goblindata, string animBoolName) : base(goblin, stateMachine, goblindata, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        foundYou = goblin.CanSeePlayer();
    }

    public override void Enter()
    {
        base.Enter();
        goblin.counter += Time.deltaTime;
        goblin.MoveGoblin(goblinData.speed);
    }

    public override void Exit()
    {
        base.Exit();
        goblin.counter = 0;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(goblin.counter > 5f)
        {
            stateMachine.ChangeState(goblin.GoblinIdleState);
        }
        else if (foundYou)
        {
            stateMachine.ChangeState(goblin.GoblinChaseState);
        }
        else if (goblin.gotHurt == true)
        {
            stateMachine.ChangeState(goblin.GoblinHurtState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
