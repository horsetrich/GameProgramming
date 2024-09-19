using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttackState : SkeletonState
{
    private bool canStillAttack;

    public SkeletonAttackState(Skeleton skeleton, SkeletonStateMachine stateMachine, SkeletonData skeletondata, string animBoolName) : base(skeleton, stateMachine, skeletondata, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        canStillAttack = skeleton.CheckAttackRange();
    }

    public override void Enter()
    {
        base.Enter();
        skeleton.counter = 0;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        skeleton.SetVelocityZero();
        if (canStillAttack && isAnimationFinished)
        {
            stateMachine.ChangeState(skeleton.SkeletonAttack2State);
        }
        else if (!canStillAttack && isAnimationFinished)
        {
            stateMachine.ChangeState(skeleton.SkeletonIdleState);
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
