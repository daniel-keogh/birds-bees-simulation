using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// In the Resting State the Bird will return to its nest and its energy level will be gradually
// restored. Once restored, the Bird will transition back to the Flying State.
public class Resting : State
{
    private Bird bird;
    private Moveable moveable;

    public Resting(GameObject go, StateMachine stateMachine) : base(go, stateMachine) { }

    public override void Enter()
    {
        base.Enter();

        bird = go.GetComponent<Bird>();
        bird.GetComponent<SpriteRenderer>().color = bird.RestingColor;

        moveable = go.GetComponent<Moveable>();
    }

    public override void Update()
    {
        base.Update();

        // Move towards the nest
        moveable.Target = bird.Nest.transform;

        if (moveable.IsStopped)
        {
            RestoreEnergy();
        }
    }

    private void RestoreEnergy()
    {
        if (bird.Energy < bird.FullEnergy)
        {
            bird.Energy += bird.RestoreEnergyRate;
        }
        else
        {
            stateMachine.CurrentState = new Flying(go, stateMachine);
        }
    }
}
