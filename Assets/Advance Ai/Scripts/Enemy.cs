using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{   
    public enum AISTATE { PATROL, CHASE, ATTACK };

    public Transform player;
    public NavMeshAgent enemy;
    public AISTATE enemyState = AISTATE.PATROL;
    public float distanceOffset = 2f;

    public List<Transform> wayPoints = new List<Transform>();
    Transform currentWayPoint;

    // Start is called before the first frame update
    void Start()
    {
        currentWayPoint = wayPoints[Random.Range(0, wayPoints.Count)];
        ChangeState(AISTATE.PATROL);
    }

    public void ChangeState(AISTATE newState)
    {
        // StopAllCoroutines();
        enemyState = newState;

        switch (enemyState)
        {
            case AISTATE.PATROL :
                StartCoroutine(PatrolState());
                break;
            case AISTATE.CHASE :
                StartCoroutine(ChaseState());
                break;
            case AISTATE.ATTACK :
                StartCoroutine(AttackState());
                break;
        }
    }

    public IEnumerator PatrolState()
    {
        while(enemyState == AISTATE.PATROL)
        {
            enemy.SetDestination(currentWayPoint.position);

            if(Vector3.Distance(transform.position, currentWayPoint.position) < distanceOffset)
            {
                currentWayPoint = wayPoints[Random.Range(0, wayPoints.Count)];
            }
            yield return null;
        }
    }

    public IEnumerator ChaseState()
    {
        while(enemyState == AISTATE.CHASE)
        {
            if(Vector3.Distance(transform.position, player.position) < distanceOffset)
            {
                ChangeState(AISTATE.ATTACK);
                yield break;
            }

            enemy.SetDestination(player.position);
            yield return null;
        }
    }

    public IEnumerator AttackState()
    {
        while(enemyState == AISTATE.ATTACK)
        {
            if(Vector3.Distance(transform.position, player.position) > distanceOffset)
            {
                ChangeState(AISTATE.PATROL);
                yield break;
            }

            print("Attack");
            enemy.SetDestination(player.position);
            yield return null;
        }
        yield break;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            ChangeState(AISTATE.CHASE);
        }
    }
}
