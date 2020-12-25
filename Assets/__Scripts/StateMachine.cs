using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class is responsible for keeping track of the current State.
 * Each individual Bird and Bee object has a reference to a StateMachine, and each StateMachine object 
 * can be in a single State at any one time. The StateMachine can switch states by setting the value of CurrentState 
 * to an instance of a class that extends the State abstract class (See State.cs).
 * 
 * Setting the CurrentState to a new value will cause the StateMachine to automatically call Exit() on the current state
 * object and Enter() on the new one.
 * 
 * References:
 * ===========
 *
 * My implementation of the state pattern was mainly influenced by the below sources:
 *
 *  - Unity AI #6 State Pattern Theory - Sqrly Code - https://www.youtube.com/watch?v=b0F8jBVuzdU
 *  - Unity AI #7 State Pattern Example - Sqrly Code - https://www.youtube.com/watch?v=GxEXkP5-C3o
*/
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
