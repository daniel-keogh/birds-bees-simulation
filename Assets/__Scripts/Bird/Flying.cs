using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// In this State, the Bird flies around its pre-determined path by setting a waypoint and then
// re-setting the waypoint once it reaches it. If a Bee is in range while the Bird is flying,
// the BeginChase() method on the ChaseController is called and the Bird goes after the Bee.
// Lastly, when the Bird runs out of energy it will transition to the Resting State and return
// to its nest.
public class Flying : State
{
    private Bird bird;
    private Moveable moveable;
    private int currentWaypoint = 0;

    public Flying(GameObject go, StateMachine stateMachine) : base(go, stateMachine) { }

    public override void Enter()
    {
        base.Enter();

        bird = go.GetComponent<Bird>();
        bird.GetComponent<SpriteRenderer>().color = bird.FlyingColor;
        moveable = bird.GetComponent<Moveable>();
    }

    public override void Update()
    {
        base.Update();

        CheckEnergy();
        FollowWaypoint();
        LookForTarget();
    }

    private void CheckEnergy()
    {
        if (bird.Energy > 0f)
        {
            bird.Energy -= bird.FlyingEnergyRate;
        }
        else
        {
            stateMachine.CurrentState = new Resting(go, stateMachine);
        }
    }

    private void LookForTarget()
    {
        // If there is a Bee within range, chase after it
        foreach (var bee in GameObject.FindObjectsOfType<Bee>())
        {
            float distance = Vector2.Distance(bird.transform.position, bee.transform.position);

            if (distance <= bird.Range)
            {
                GameObject.FindObjectOfType<ChaseController>()?.BeginChase(bee, bird);
                return;
            }
        }
    }

    private void FollowWaypoint()
    {
        moveable.Target = bird.Waypoints[currentWaypoint].transform;

        if (moveable.IsStopped)
        {
            // Set a new waypoint
            if (currentWaypoint == bird.Waypoints.Length - 1)
            {
                currentWaypoint = 0;
            }
            else
            {
                currentWaypoint++;
            }
        }
    }
}
