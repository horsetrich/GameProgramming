using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStartState : SkeletonState
{
    private bool playerHere;

    public SkeletonStartState(Skeleton skeleton, SkeletonStateMachine stateMachine, SkeletonData skeletondata, string animBoolName) : base(skeleton, stateMachine, skeletondata, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        playerHere = skeleton.CheckRange();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        skeleton.counter = 0;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (playerHere)
        {
            stateMachine.ChangeState(skeleton.SkeletonRiseState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
