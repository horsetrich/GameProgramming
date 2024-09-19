using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStateMachine
{
    public SkeletonState CurrentState { get; private set; }

    public void Initialize(SkeletonState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(SkeletonState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
