using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinChaseState : GoblinGroundedState
{
    protected bool inRange;

    public GoblinChaseState(Goblin goblin, GoblinStateMachine stateMachine, GoblinData goblindata, string animBoolName) : base(goblin, stateMachine, goblindata, animBoolName)
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
        goblin.counter = 0;
        
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        goblin.SetVelocityX(goblinData.fastSpeed);
        goblin.CheckIfShouldFlip();
        if(inRange)
        {
            stateMachine.ChangeState(goblin.GoblinAttackState);
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
