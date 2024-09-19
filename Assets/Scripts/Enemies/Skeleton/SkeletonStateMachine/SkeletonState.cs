using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonState
{
    protected Skeleton skeleton;
    protected SkeletonStateMachine stateMachine;
    protected SkeletonData skeletonData;


    protected bool isAnimationFinished;
    protected bool isExitingState;

    protected float startTime;


    private string animBoolName;


    public SkeletonState(Skeleton skeleton, SkeletonStateMachine stateMachine, SkeletonData skeletondata, string animBoolName)
    {
        this.skeleton = skeleton;
        this.stateMachine = stateMachine;
        this.skeletonData = skeletondata;
        this.animBoolName = animBoolName;

    }

    public virtual void Enter()
    {
        DoChecks();
        skeleton.Anim.SetBool(animBoolName, true);
        startTime = Time.time;
        isAnimationFinished = false;
        isExitingState = false;
    }

    public virtual void Exit()
    {
        skeleton.Anim.SetBool(animBoolName, false);
        isExitingState = true;
    }

    public virtual void LogicUpdate()
    {

    }


    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {

    }

    public virtual void AnimationTrigger() { }

    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;
}
