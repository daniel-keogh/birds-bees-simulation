using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class is extended by each individual State in the system and each of the below virtual
 * methods may or may not be implemented by a derived class.
 *
 * The Bird and Bee objects each hold a reference to a StateMachine instance. When the StateMachine is instantiated in
 * the Awake() method of the Bird & Bee classes, each Bird/Bee object will set their initial State.
 * The Update() method should be called on every frame, and is responsible for switching the State if the condition for doing so is met.
 * Whenever the state changes, the Exit() method should be called and this is done automatically by the
 * StateMachine class in the CurrentState setter. Finally, the OnTriggerEnter2D() method is responsible
 * for detecting collisions between the Bird and Bee objects.
 *
 * This class holds a reference to a GameObject, which is the object to which the state applies (i.e. a Bird/Bee),
 * as well as a StateMachine which is responsible for managing the transitions between states. (By setting
 * CurrentState to a different deriving class.)
 * 
 * 
 * References:
 * ===========
 *
 * My implementation of the state pattern was mainly influenced by the below sources:
 *  - Unity AI #6 State Pattern Theory - Sqrly Code - https://www.youtube.com/watch?v=b0F8jBVuzdU
 *  - Unity AI #7 State Pattern Example - Sqrly Code - https://www.youtube.com/watch?v=GxEXkP5-C3o
*/
public abstract class State
{
    protected GameObject go;
    protected StateMachine stateMachine;

    public State(GameObject go, StateMachine stateMachine)
    {
        this.go = go;
        this.stateMachine = stateMachine;
    }

    public virtual void Update()
    {

    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {

    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }
}
