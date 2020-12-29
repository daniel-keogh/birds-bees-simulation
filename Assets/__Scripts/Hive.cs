using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive : MonoBehaviour
{
    [SerializeField] private Bee beePrefab;
    [SerializeField] private int numBees = 4;

    void Start()
    {
        for (int i = 0; i < numBees; i++)
        {
            // Spawn the bees at the hive
            Instantiate<Bee>(beePrefab, transform.position, Quaternion.identity);
        }
    }
}
