using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrulla : MonoBehaviour
{
    public float speed;
    public Transform[] patrolpoints;
    private int actualpoint = 0;

    private void Update()
    {
        // Mueve el enemigo hacia el punto de patrulla actual
        transform.position = Vector3.MoveTowards(transform.position, patrolpoints[actualpoint].position, speed * Time.deltaTime);

        // Si el enemigo ha llegado al punto de patrulla actual, cambia al siguiente punto de patrulla
        if (transform.position == patrolpoints[actualpoint].position)
        {
            actualpoint = (actualpoint + 1) % patrolpoints.Length;
        }

    }
}
