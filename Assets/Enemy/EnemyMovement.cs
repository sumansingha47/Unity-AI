using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float fov = 120f; // fov = Field of View
    public Transform target;
    public bool inSight;

    public float AwakeDistance = 200f;
    public bool AwareOfPlayer;
    public NavMeshAgent enemyAgent;


    private void Update() {

        drawRay();
        float PlayerDistance = Vector3.Distance(target.position, transform.position);
        Vector3 playerDirection = target.position - transform.position;
        float playerAngle = Vector3.Angle(transform.forward, playerDirection);
        if(playerAngle <= fov/2f)
        {
            inSight = true;
            Debug.Log("PlayerinSight");
        } else {
            inSight = false;
        }
        if(inSight == true && PlayerDistance <= AwakeDistance) {
            AwareOfPlayer = true;
        }

        if(AwareOfPlayer == true) {
            enemyAgent.SetDestination(target.position);
        }
    }

    void drawRay()
    {
        
    }
}
