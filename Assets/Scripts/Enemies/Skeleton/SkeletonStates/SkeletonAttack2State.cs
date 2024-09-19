using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack2State : SkeletonState
{


    public SkeletonAttack2State(Skeleton skeleton, SkeletonStateMachine stateMachine, SkeletonData skeletondata, string animBoolName) : base(skeleton, stateMachine, skeletondata, animBoolName)
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
        skeleton.SetVelocityZero();
        if (isAnimationFinished)
        {
            stateMachine.ChangeState(skeleton.SkeletonChaseState);
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
