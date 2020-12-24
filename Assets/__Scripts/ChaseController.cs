using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseController : MonoBehaviour
{
    private static ChaseController instance;

    private Bird[] birds;
    private Bee[] bees;

    void Awake()
    {
        SetupSingleton();
    }

    void Start()
    {
        birds = FindObjectsOfType<Bird>();
        bees = FindObjectsOfType<Bee>();
    }

    private void SetupSingleton()
    {
        // Make this object a singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);
    }
}
