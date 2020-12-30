using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// In this State the Bird's energy is restored and the ChaseController singleton
// is notified that a Bee was eaten. Afterwards, The Bird transitions back
// to the Flying State.
public class Eating : State
{
    private Bird bird;
    private ChaseController chaseController;

    public Eating(GameObject go, StateMachine stateMachine) : base(go, stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        bird = go.GetComponent<Bird>();
        bird.GetComponent<SpriteRenderer>().color = bird.EatingColor;

        chaseController = GameObject.FindObjectOfType<ChaseController>();
    }

    public override void Update()
    {
        base.Update();

        bird.Energy = bird.FullEnergy;

        chaseController?.ShowUIMessage("Bee gets eaten...");

        stateMachine.CurrentState = new Flying(go, stateMachine);
    }
}
