using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonDeadState : SkeletonState
{

    public SkeletonDeadState(Skeleton skeleton, SkeletonStateMachine stateMachine, SkeletonData skeletondata, string animBoolName) : base(skeleton, stateMachine, skeletondata, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

    }

    public override void Enter()
    {
        base.Enter();
        skeleton.TurnOffHealthBar();
        skeleton.enemyHealthThing.CanKill();
        skeleton.counter += Time.deltaTime;
        skeleton.SetColliderHeight(skeletonData.deadColliderHeight);
    }

    public override void Exit()
    {
        base.Exit();
        skeleton.SetHeightBack(skeletonData.upColliderHeight);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAnimationFinished)
        {
            if (skeleton.counter > 10)
            {
                stateMachine.ChangeState(skeleton.SkeletonRiseState);
                skeleton.isDead = false;
            }
        }


    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
