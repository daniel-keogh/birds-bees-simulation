using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// When in this State the Bee will Flee back to the Hive by setting the
// target variable in the Moveable class to the transform of the Hive gameObject.
public class Fleeing : State
{
    private Bee bee;
    private Moveable moveable;
    private Hive hive;

    public Fleeing(GameObject go, StateMachine stateMachine) : base(go, stateMachine) { }

    public override void Enter()
    {
        base.Enter();

        bee = go.GetComponent<Bee>();
        bee.GetComponent<SpriteRenderer>().color = bee.FleeColor;

        hive = GameObject.FindObjectOfType<Hive>();
        moveable = go.GetComponent<Moveable>();

        moveable.Target = hive.transform;
    }

    public override void Update()
    {
        base.Update();
        DrainEnergy();
    }

    private void DrainEnergy()
    {
        if (bee.Energy > 0f)
        {
            bee.Energy -= bee.FleeEnergyRate;
        }
        else
        {
            stateMachine.CurrentState = new AtHive(go, stateMachine);
        }
    }
}
