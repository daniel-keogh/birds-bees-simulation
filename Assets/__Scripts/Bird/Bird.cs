using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Bird : MonoBehaviour
{
    [SerializeField] private float range;

    [Header("Energy")]
    [SerializeField] private float energy;
    [SerializeField] private float energyRestoreRate = 0.3f;
    [SerializeField] private float flyingEnergyRate = 0.4f;
    [SerializeField] private float chaseEnergyRate = 0.8f;

    [Header("UI")]
    [SerializeField] private Color chasingColor;
    [SerializeField] private Color flyingColor;
    [SerializeField] private Color eatingColor;
    [SerializeField] private Color restingColor;

    public float Energy
    {
        get => energy;
        set => energy = value;
    }

    public float FullEnergy
    {
        get => fullEnergy;
    }

    public float EnergyRestoreRate
    {
        get => energyRestoreRate;
    }

    public float FlyingEnergyRate
    {
        get => flyingEnergyRate;
    }

    public float ChaseEnergyRate
    {
        get => chaseEnergyRate;
    }

    public Color ChasingColor
    {
        get => chasingColor;
    }

    public Color FlyingColor
    {
        get => flyingColor;
    }

    public Color EatingColor
    {
        get => eatingColor;
    }

    public Color RestingColor
    {
        get => restingColor;
    }

    private float fullEnergy;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = restingColor;
        fullEnergy = energy;
    }

    void Update()
    {

    }
}
