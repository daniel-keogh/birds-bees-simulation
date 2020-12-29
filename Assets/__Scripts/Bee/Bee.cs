using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Each Bee holds a reference to a StateMachine instance. The Bee object sets
// the initial State to AtHive and calls the Update() method on the current state
// on every frame. OnTriggerEnter2D() is also called whenever a collision occurs.
[RequireComponent(typeof(Moveable))]
[RequireComponent(typeof(SpriteRenderer))]
public class Bee : MonoBehaviour
{
    [Header("Nectar")]
    [SerializeField] private float nectarPayload = 10f;
    [SerializeField] private float maxNectar = 100f;
    [SerializeField] private float nectarLoadRate = 0.2f;
    [SerializeField] private float nectarUnloadRate = 0.2f;

    [Header("Energy")]
    [SerializeField] private float energy = 100f;
    [SerializeField] private float lowEnergyValue = 0f;
    [SerializeField] private float searchEnergyRate = 0.1f;
    [SerializeField] private float restoreEnergyRate = 0.2f;
    [SerializeField] private float fleeEnergyRate = 0.3f;

    [Header("UI")]
    [SerializeField] private Color searchingColor;
    [SerializeField] private Color gatheringColor;
    [SerializeField] private Color dancingColor;
    [SerializeField] private Color atHiveColor;
    [SerializeField] private Color fleeColor;

    private float fullEnergy;
    private StateMachine stateMachine;

    public float NectarPayload
    {
        get => nectarPayload;
        set => nectarPayload = value;
    }

    public float Energy
    {
        get => energy;
        set => energy = value;
    }

    public float MaxNectar => maxNectar;
    public float NectarLoadRate => nectarLoadRate;
    public float NectarUnloadRate => nectarUnloadRate;
    public float LowEnergyValue => lowEnergyValue;
    public float FullEnergy => fullEnergy;
    public float SearchEnergyRate => searchEnergyRate;
    public float RestoreEnergyRate => restoreEnergyRate;
    public float FleeEnergyRate => fleeEnergyRate;
    public Color SearchingColor => searchingColor;
    public Color GatheringColor => gatheringColor;
    public Color DancingColor => dancingColor;
    public Color AtHiveColor => atHiveColor;
    public Color FleeColor => fleeColor;
    public StateMachine StateMachine => stateMachine;

    void Awake()
    {
        fullEnergy = energy;
        energy = 0f;

        stateMachine = new StateMachine();
        stateMachine.CurrentState = new AtHive(gameObject, stateMachine);
    }

    void Update()
    {
        stateMachine.CurrentState.Update();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        stateMachine.CurrentState.OnTriggerEnter2D(other);
    }
}
