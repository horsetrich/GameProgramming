using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonHurtState : SkeletonState
{
    public SkeletonHurtState(Skeleton skeleton, SkeletonStateMachine stateMachine, SkeletonData skeletondata, string animBoolName) : base(skeleton, stateMachine, skeletondata, animBoolName)
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
        if (isAnimationFinished)
        {
            stateMachine.ChangeState(skeleton.SkeletonChaseState);
            skeleton.gotHurt = false;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
