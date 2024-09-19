using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonChaseState : SkeletonState
{
    private bool canAttack;

    public SkeletonChaseState(Skeleton skeleton, SkeletonStateMachine stateMachine, SkeletonData skeletondata, string animBoolName) : base(skeleton, stateMachine, skeletondata, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        canAttack = skeleton.CheckAttackRange();
    }

    public override void Enter()
    {
        base.Enter();
        skeleton.counter += Time.deltaTime;
    }

    public override void Exit()
    {
        base.Exit();
        skeleton.SetVelocityZero();
        skeleton.counter = 0;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        skeleton.SetVelocityX(skeletonData.speed);
        skeleton.CheckIfShouldFlip();
        if (canAttack)
        {
            stateMachine.ChangeState(skeleton.SkeletonAttackState);
        }
        else if(skeleton.counter > 5)
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
