using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Each Bird holds a reference to a StateMachine instance. The Bird object sets
// the initial State to Resting and calls the Update() method on the current state
// on every frame. OnTriggerEnter2D() is also called whenever a collision occurs.
[RequireComponent(typeof(Moveable))]
[RequireComponent(typeof(SpriteRenderer))]
public class Bird : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private GameObject nest;

    [Header("Energy")]
    [SerializeField] private float energy;
    [SerializeField] private float restoreEnergyRate = 0.3f;
    [SerializeField] private float flyingEnergyRate = 0.4f;
    [SerializeField] private float chaseEnergyRate = 0.8f;

    [Header("UI")]
    [SerializeField] private Color chasingColor;
    [SerializeField] private Color flyingColor;
    [SerializeField] private Color eatingColor;
    [SerializeField] private Color restingColor;

    private float fullEnergy;
    private StateMachine stateMachine;

    public float Energy
    {
        get => energy;
        set => energy = value;
    }

    public GameObject Nest => nest;
    public float Range => range;
    public float FullEnergy => fullEnergy;
    public float RestoreEnergyRate => restoreEnergyRate;
    public float FlyingEnergyRate => flyingEnergyRate;
    public float ChaseEnergyRate => chaseEnergyRate;
    public Color ChasingColor => chasingColor;
    public Color FlyingColor => flyingColor;
    public Color EatingColor => eatingColor;
    public Color RestingColor => restingColor;

    void Awake()
    {
        fullEnergy = energy;
        energy = 0f;

        stateMachine = new StateMachine();
        stateMachine.CurrentState = new Resting(gameObject, stateMachine);
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
