using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BspiritState
{
    protected BossSpirit bossSpirit;
    protected BspiritStateMachine stateMachine;
    protected BossSpiritData bossData;


    protected bool isAnimationFinished;
    protected bool isExitingState;

    protected float startTime;


    private string animBoolName;


    public BspiritState(BossSpirit bossSpirit, BspiritStateMachine stateMachine, BossSpiritData bossData, string animBoolName)
    {
        this.bossSpirit = bossSpirit;
        this.stateMachine = stateMachine;
        this.bossData = bossData;
        this.animBoolName = animBoolName;

    }

    public virtual void Enter()
    {
        DoChecks();
        bossSpirit.Anim.SetBool(animBoolName, true);
        startTime = Time.time;
        isAnimationFinished = false;
        isExitingState = false;
    }

    public virtual void Exit()
    {
        bossSpirit.Anim.SetBool(animBoolName, false);
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
