using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinStateMachine
{
    public GoblinState CurrentState { get; private set; }

    public void Initialize(GoblinState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(GoblinState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
