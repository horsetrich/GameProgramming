using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BspiritStateMachine
{
    public BspiritState CurrentState { get; private set; }

    public void Initialize(BspiritState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(BspiritState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
