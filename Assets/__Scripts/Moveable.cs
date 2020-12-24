using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector3 target;

    public Vector3 Target
    {
        get => target;
        set => target = value;
    }

    void Start()
    {

    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (target.magnitude > 0f)
        {
            // Get the distance from the target
            var distance = Vector2.Distance(transform.position, target);

            if (distance > Mathf.Epsilon)
            {
                // Move towards the target
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    target,
                    speed * Time.deltaTime
                );
            }
            else if (distance < Mathf.Epsilon)
            {
                transform.position = this.transform.position;
            }
        }
    }
}
