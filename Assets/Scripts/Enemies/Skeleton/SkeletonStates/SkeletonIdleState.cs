using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIdleState : SkeletonState
{
    private bool inRange;
    public SkeletonIdleState(Skeleton skeleton, SkeletonStateMachine stateMachine, SkeletonData skeletondata, string animBoolName) : base(skeleton, stateMachine, skeletondata, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        inRange = skeleton.CheckAttackRange();
    }

    public override void Enter()
    {
        base.Enter();
        skeleton.counter += Time.deltaTime;
    }

    public override void Exit()
    {
        base.Exit();
        skeleton.counter = 0;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (skeleton.counter > 2)
        {
            stateMachine.ChangeState(skeleton.SkeletonChaseState);
        }
        else if (inRange)
        {
            stateMachine.ChangeState(skeleton.SkeletonAttackState);
        }
        else if (skeleton.gotHurt)
        {
            stateMachine.ChangeState(skeleton.SkeletonHurtState);
        }
        else if (skeleton.isDead)
        {
            stateMachine.ChangeState(skeleton.SkeletonDeadState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
