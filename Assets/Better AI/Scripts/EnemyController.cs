using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public enum AISTATE { PATROL, CHASE, ATTACK };

    public Transform player;
    public NavMeshAgent enemy;
    public AISTATE enemyState = AISTATE.PATROL;
    float distanceOffset = 2f;

    public List<Transform> waypoints = new List<Transform>();
    Transform currentWaypoint;

    private void Start()
    {
        currentWaypoint = waypoints[Random.Range(0, waypoints.Count)];
        StartCoroutine(PatrolState());
    }


    public IEnumerator PatrolState()
    {       
        while (enemyState == AISTATE.PATROL)
        {
            enemy.SetDestination(currentWaypoint.position);

            if(Vector3.Distance(transform.position, currentWaypoint.position) < distanceOffset)
            {
                currentWaypoint = waypoints[Random.Range(0, waypoints.Count)];
            }
            yield return null;
        }
    }

    
}
