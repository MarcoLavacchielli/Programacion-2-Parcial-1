using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float range = 10f;
    public float speed = 5f;
    private bool isFollowing;
    Charview view;

    private void Awake()
    {
        view = GetComponent<Charview>();
    }
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= range)
        {
            isFollowing = true;
            view.Isrunning(true);
        }
        else
        {
            isFollowing = false;
            view.Isrunning(false);
        }

        if (isFollowing)
        {
            Vector3 direction = (player.position - transform.position).normalized;

            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
