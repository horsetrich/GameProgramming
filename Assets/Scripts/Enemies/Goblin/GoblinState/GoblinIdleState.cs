using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinIdleState : GoblinGroundedState
{
    public bool foundYou;
    public GoblinIdleState(Goblin goblin, GoblinStateMachine stateMachine, GoblinData goblindata, string animBoolName) : base(goblin, stateMachine, goblindata, animBoolName)
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
        goblin.SetVelocityZero();
    }

    public override void Exit()
    {
        base.Exit();
        goblin.Flip();
        goblin.counter = 0;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(!isExitingState)
        {
            if (goblin.counter > 2)
            {
                stateMachine.ChangeState(goblin.GoblinPatrol);
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

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
