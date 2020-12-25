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
    private Hive hive;

    public AtHive(GameObject go, StateMachine stateMachine) : base(go, stateMachine) { }

    public override void Enter()
    {
        base.Enter();

        bee = go.GetComponent<Bee>();
        bee.GetComponent<SpriteRenderer>().color = bee.AtHiveColor;

        moveable = go.GetComponent<Moveable>();
        hive = GameObject.FindObjectOfType<Hive>();
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
            UnloadNectar();
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

    private void UnloadNectar()
    {
        if (bee.NectarPayload > 0f)
        {
            var distance = Vector2.Distance(go.transform.position, hive.transform.position);

            // When the bee returns to the hive with nectar, it "dances" for other bees until the nectar is unloaded
            if (distance <= 0.1f)
            {
                stateMachine.CurrentState = new Dancing(go, stateMachine);
            }
        }
    }
}
