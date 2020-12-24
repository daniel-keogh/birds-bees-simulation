using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : State
{
    public Flying(GameObject go, StateMachine stateMachine) : base(go, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Update()
    {
        base.Update();
    }
}
