using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// When in this state the Bee will randomly move towards the location of one
// of the flowers in the scene. When it reaches a flower, it will transition to
// the Gathering State. If the Bee runs out of energy, it will transition to the AtHive
// State and return to the Hive.
public class Searching : State
{
    private Bee bee;

    public Searching(GameObject go, StateMachine stateMachine) : base(go, stateMachine) { }

    public override void Enter()
    {
        base.Enter();

        bee = go.GetComponent<Bee>();
        bee.GetComponent<SpriteRenderer>().color = bee.SearchingColor;

        Moveable moveable = go.GetComponent<Moveable>();
        GameObject[] flowers = GameObject.FindGameObjectsWithTag(Tags.FLOWER);

        // Pick a flower to move to
        moveable.Target = flowers[Random.Range(0, flowers.Length)].transform;
    }

    public override void Update()
    {
        base.Update();
        DrainEnergy();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if (other.gameObject.tag == Tags.FLOWER)
        {
            stateMachine.CurrentState = new Gathering(go, stateMachine);
        }
    }

    private void DrainEnergy()
    {
        if (bee.Energy > 0f)
        {
            bee.Energy -= bee.SearchEnergyRate;
        }
        else
        {
            stateMachine.CurrentState = new AtHive(go, stateMachine);
        }
    }
}
