using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : State
{
    private Bird bird;
    private Bee[] bees;

    public Chasing(GameObject go, StateMachine stateMachine) : base(go, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        bird = go.GetComponent<Bird>();
        bees = GameObject.FindObjectsOfType<Bee>();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        Vector3 closestRunnerPos = GetClosestRunnerPos();
        Vector3 runDirection = (closestRunnerPos - go.transform.position).normalized;

        bird.GetComponent<Moveable>().Target = runDirection;
    }

    public override void Update()
    {
        base.Update();
    }

    private Vector3 GetClosestRunnerPos()
    {
        Bee closestBee = null;
        float curMinDistance = 999999f;

        for (int i = 0; i < bees.Length; i++)
        {
            float distance = Vector3.Distance(go.transform.position, bees[i].transform.position);

            if (distance < curMinDistance)
            {
                curMinDistance = distance;
                closestBee = bees[i];
            }
        }

        return closestBee.transform.position;
    }
}
