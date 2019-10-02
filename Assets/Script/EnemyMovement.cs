using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

    private Transform traget;
    private int wavepointIndex = 0;

    private Enemy enemy;

    private void Start()
    {
        traget = Waypoint.points[0];
        enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        Vector3 dir = traget.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, traget.position) <= 0.2f)
        {
            GetNextWavepoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    void GetNextWavepoint()
    {
        if (wavepointIndex >= Waypoint.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        traget = Waypoint.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStatus.Lives--;
        WaveSpawner.EnemiesAlive--;
        enemy.Die();
    }

}
