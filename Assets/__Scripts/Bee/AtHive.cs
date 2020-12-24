using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Bee))]
[RequireComponent(typeof(SpriteRenderer))]
public class AtHive : State
{
    private Bee bee;

    public AtHive(GameObject go, StateMachine stateMachine) : base(go, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        bee = go.GetComponent<Bee>();
        bee.GetComponent<SpriteRenderer>().color = bee.AtHiveColor;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Update()
    {
        base.Update();
        RestoreEnergy();
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
