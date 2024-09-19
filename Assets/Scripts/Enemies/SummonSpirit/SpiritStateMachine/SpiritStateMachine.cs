using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritStateMachine
{
    public SpiritState CurrentState { get; private set; }

    public void Initialize(SpiritState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(SpiritState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
