using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// When in this State the Bee will flee back to the Hive by setting the
// target variable in the Moveable class to the transform of the Hive GameObject.
//
// When the Bee collides with the Hive, the BeeEscaped() method on the ChaseController
// is called, bringing the chase to an end.
public class Fleeing : State
{
    private Bee bee;
    private Hive hive;
    private ChaseController chaseController;

    public Fleeing(GameObject go, StateMachine stateMachine) : base(go, stateMachine) { }

    public override void Enter()
    {
        base.Enter();

        bee = go.GetComponent<Bee>();
        bee.GetComponent<SpriteRenderer>().color = bee.FleeColor;

        hive = GameObject.FindObjectOfType<Hive>();
        chaseController = GameObject.FindObjectOfType<ChaseController>();

        Moveable moveable = go.GetComponent<Moveable>();
        moveable.Target = hive.transform;
    }

    public override void Update()
    {
        base.Update();
        DrainEnergy();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if (other.gameObject.tag == Tags.HIVE)
        {
            chaseController?.BeeEscaped(bee);
        }
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
