using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This state unloads the nectar collected before transitioning to the AtHive State
public class Dancing : State
{
    private Bee bee;

    public Dancing(GameObject go, StateMachine stateMachine) : base(go, stateMachine) { }

    public override void Enter()
    {
        base.Enter();

        bee = go.GetComponent<Bee>();
        bee.GetComponent<SpriteRenderer>().color = bee.DancingColor;
    }

    public override void Update()
    {
        base.Update();
        Dance();
    }

    private void Dance()
    {
        if (bee.NectarPayload > 0f)
        {
            bee.NectarPayload -= bee.NectarUnloadRate;
        }
        else
        {
            stateMachine.CurrentState = new AtHive(go, stateMachine);
        }
    }
}
