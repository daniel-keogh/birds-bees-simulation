using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// When the Bee's StateMachine is in this State, the Bee will return to the
// Hive and unload the nectar collected. After all the nectar has been
// unloaded (by switching to the Dancing State), energy will be gradually restored
// before transitioning to the Searching State.
public class AtHive : State
{
    private Bee bee;
    private Moveable moveable;

    public AtHive(GameObject go, StateMachine stateMachine) : base(go, stateMachine) { }

    public override void Enter()
    {
        base.Enter();

        bee = go.GetComponent<Bee>();
        bee.GetComponent<SpriteRenderer>().color = bee.AtHiveColor;

        moveable = go.GetComponent<Moveable>();
    }

    public override void Update()
    {
        base.Update();

        // Move towards the hive
        moveable.Target = GameObject.FindObjectOfType<Hive>().transform;

        if (moveable.IsStopped)
        {
            // Bee is at the hive
            RestoreEnergy();
        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if (bee.NectarPayload > 0f)
        {
            if (other.gameObject.tag == Tags.HIVE)
            {
                stateMachine.CurrentState = new Dancing(go, stateMachine);
            }
        }
    }

    private void RestoreEnergy()
    {
        if (bee.Energy < bee.FullEnergy)
        {
            bee.Energy += bee.RestoreEnergyRate;
        }
        else
        {
            stateMachine.CurrentState = new Searching(go, stateMachine);
        }
    }
}
