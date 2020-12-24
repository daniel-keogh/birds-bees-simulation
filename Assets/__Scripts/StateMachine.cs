using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private State currentState;

    public State CurrentState
    {
        get => currentState;
        set
        {
            currentState?.Exit();
            currentState = value;
            currentState?.Enter();
        }
    }
}
