using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonRiseState : SkeletonState
{

    public SkeletonRiseState(Skeleton skeleton, SkeletonStateMachine stateMachine, SkeletonData skeletondata, string animBoolName) : base(skeleton, stateMachine, skeletondata, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

    }

    public override void Enter()
    {
        base.Enter();
        skeleton.TurnOnHealthBar();
        skeleton.counter += Time.deltaTime;
        skeleton.enemyHealthThing.CanNotKill();
    }

    public override void Exit()
    {
        base.Exit();
        skeleton.counter = 0;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        skeleton.enemyHealthThing.enemyHealth = skeleton.enemyHealthThing.maxEnemyHealth;
        if(isAnimationFinished && skeleton.counter > 1)
        {
            stateMachine.ChangeState(skeleton.SkeletonIdleState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
