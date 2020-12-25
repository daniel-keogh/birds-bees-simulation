using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class adds the move behaviour to the Bird and Bee objects.
// The Bird/Bee will move towards a "target" transform if it is set,
// otherwise it will remain fixed in its current position.
public class Moveable : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    private Transform target;
    private bool isStopped = false;

    public Transform Target
    {
        get => target;
        set => target = value;
    }

    public bool IsStopped => isStopped;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (target != null)
        {
            // Get the distance from the target
            var distance = Vector2.Distance(transform.position, target.position);

            if (distance > 0.1f)
            {
                // Move towards the target
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    target.position,
                    speed * Time.deltaTime
                );
                isStopped = false;
            }
            else
            {
                transform.position = this.transform.position;
                isStopped = true;
            }
        }
    }
}
