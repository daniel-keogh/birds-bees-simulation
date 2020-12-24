using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Bee : MonoBehaviour
{
    [Header("Nectar")]
    [SerializeField] private float nectarPayload;
    [SerializeField] private float nectarUnloadRate = 0.2f;

    [Header("Energy")]
    [SerializeField] private float energy;
    [SerializeField] private float lowEnergyValue;
    [SerializeField] private float searchEnergyRate = 0.1f;
    [SerializeField] private float restoreEnergyRate = 0.2f;
    [SerializeField] private float fleeEnergyRate = 0.3f;

    [Header("UI")]
    [SerializeField] private Color searchingColor;
    [SerializeField] private Color gatheringColor;
    [SerializeField] private Color dancingColor;
    [SerializeField] private Color atHiveColor;

    private float fullEnergy;
    private SpriteRenderer spriteRenderer;
    private Hive hive;
    private StateMachine stateMachine;

    public float Energy
    {
        get => energy;
        set => energy = value;
    }

    public float FullEnergy
    {
        get => fullEnergy;
    }

    public float LowEnergyValue
    {
        get => lowEnergyValue;
    }

    public float SearchEnergyRate
    {
        get => searchEnergyRate;
    }

    public float RestoreEnergyRate
    {
        get => restoreEnergyRate;
    }

    public float FleeEnergyRate
    {
        get => fleeEnergyRate;
    }

    public Color SearchingColor
    {
        get => searchingColor;
    }

    public Color GatheringColor
    {
        get => gatheringColor;
    }

    public Color DancingColor
    {
        get => dancingColor;
    }

    public Color AtHiveColor
    {
        get => atHiveColor;
    }

    void Awake()
    {
        stateMachine = new StateMachine();
        stateMachine.CurrentState = new AtHive(gameObject, stateMachine);
    }

    void Start()
    {
        hive = FindObjectOfType<Hive>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = atHiveColor;
        fullEnergy = energy;
    }

    void Update()
    {
        stateMachine.CurrentState.Update();
    }

    void FixedUpdate()
    {
        stateMachine.CurrentState.FixedUpdate();
    }
}
