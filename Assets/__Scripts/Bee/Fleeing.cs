using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleeing : State
{
    private Bee bee;

    public Fleeing(GameObject go, StateMachine stateMachine) : base(go, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        bee = go.GetComponent<Bee>();
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
