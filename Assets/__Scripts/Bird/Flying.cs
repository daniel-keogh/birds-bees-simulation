using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// In this State, the Bird flys around in a random path by setting waypoints and then
// re-setting the waypoint one it reaches that position. If a Bee is in range while the
// Bird is flying, the Bird transitions to the Chasing State and goes after the Bee.
// Lastly, if the Bird runs out of energy it will transition to the Resting State and return
// to its nest.
public class Flying : State
{
    private Bird bird;
    private Moveable moveable;
    private Vector3 viewport;
    private Transform waypoint;

    public Flying(GameObject go, StateMachine stateMachine) : base(go, stateMachine) { }

    public override void Enter()
    {
        base.Enter();

        bird = go.GetComponent<Bird>();
        bird.GetComponent<SpriteRenderer>().color = bird.FlyingColor;

        viewport = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // Place the waypoint at a random position within the scene
        waypoint = new GameObject("Waypoint").transform;
        waypoint.position = new Vector2(
            Random.Range(-viewport.x, viewport.x),
            Random.Range(-viewport.y, viewport.y)
        );

        moveable = go.GetComponent<Moveable>();
    }

    public override void Update()
    {
        base.Update();

        CheckEnergy();
        FollowWaypoint();
        LookForTarget();
    }

    public override void Exit()
    {
        base.Exit();
        GameObject.Destroy(waypoint.gameObject);
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
        foreach (var bee in GameObject.FindObjectsOfType<Bee>())
        {
            float distance = Vector2.Distance(bird.transform.position, bee.transform.position);

            if (distance <= bird.Range)
            {
                stateMachine.CurrentState = new Chasing(go, stateMachine, bee.gameObject);
                return;
            }
        }
    }

    private void FollowWaypoint()
    {
        moveable.Target = waypoint.transform;

        if (moveable.IsStopped)
        {
            // Set a new waypoint
            waypoint.position = new Vector2(
                Random.Range(-viewport.x, viewport.x),
                Random.Range(-viewport.y, viewport.y)
            );
        }
    }
}
