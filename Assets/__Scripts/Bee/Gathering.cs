using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// When in this State the Bee will gather nectar. Once finished it will transition
// to the AtHive State where the nectar will be unloaded.
public class Gathering : State
{
    private Bee bee;

    public Gathering(GameObject go, StateMachine stateMachine) : base(go, stateMachine) { }

    public override void Enter()
    {
        base.Enter();

        bee = go.GetComponent<Bee>();
        bee.GetComponent<SpriteRenderer>().color = bee.GatheringColor;
    }

    public override void Update()
    {
        base.Update();
        Gather();
    }

    private void Gather()
    {
        if (bee.NectarPayload < bee.MaxNectar)
        {
            bee.NectarPayload += bee.NectarLoadRate;
        }
        else
        {
            stateMachine.CurrentState = new AtHive(go, stateMachine);
        }
    }
}
