using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// When in this State the Bird will chase a target GameObject that is passed in via
// the constructor. If the Bird runs out of energy it will transition to the Resting
// State and return to the nest. If the Bird catches the Bee, the OnTriggerEnter2D() callback
// is invoked, the Bee GameObject is then destroyed and the Bird transitions to the Eating State. 
public class Chasing : State
{
    private Bird bird;
    private GameObject target;

    public Chasing(GameObject go, StateMachine stateMachine) : base(go, stateMachine) { }

    public Chasing(GameObject go, StateMachine stateMachine, GameObject target) : base(go, stateMachine)
    {
        this.target = target;
    }

    public override void Enter()
    {
        base.Enter();
        bird = go.GetComponent<Bird>();
        bird.GetComponent<SpriteRenderer>().color = bird.ChasingColor;
    }

    public override void Update()
    {
        base.Update();

        CheckEnergy();

        if (target != null)
        {
            bird.GetComponent<Moveable>().Target = target.transform;
        }
        else
        {
            // No target exists transition to Flying State
            stateMachine.CurrentState = new Flying(go, stateMachine);
        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bee")
        {
            GameObject.Destroy(other.gameObject);
            stateMachine.CurrentState = new Eating(go, stateMachine);
        }
    }

    private void CheckEnergy()
    {
        if (bird.Energy > 0f)
        {
            bird.Energy -= bird.ChaseEnergyRate;
        }
        else
        {
            stateMachine.CurrentState = new Resting(go, stateMachine);
        }
    }
}
