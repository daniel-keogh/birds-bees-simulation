using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public virtual void FixedUpdate()
    {

    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }
}
