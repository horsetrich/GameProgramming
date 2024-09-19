using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritState
{
    protected Spirit Spirit;
    protected SpiritStateMachine SpiritStateMachine;
    protected SpiritData spiritData;


    protected bool isAnimationFinished;
    protected bool isExitingState;

    protected float startTime;


    private string animBoolName;


    public SpiritState(Spirit spirit, SpiritStateMachine StateMachine, SpiritData spiritData, string animBoolName)
    {
        this.Spirit = spirit;
        this.SpiritStateMachine = StateMachine;
        this.spiritData = spiritData;
        this.animBoolName = animBoolName;

    }

    public virtual void Enter()
    {
        DoChecks();
        Spirit.Anim.SetBool(animBoolName, true);
        startTime = Time.time;
        isAnimationFinished = false;
        isExitingState = false;
    }

    public virtual void Exit()
    {
        Spirit.Anim.SetBool(animBoolName, false);
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
