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
    public bool playerinVision;


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
        if(inSight == true && PlayerDistance <= AwakeDistance && playerinVision == true) {
            AwareOfPlayer = true;
        }

        if(AwareOfPlayer == true) {
            enemyAgent.SetDestination(target.position);
        }
    }

    void drawRay()
    {
        Vector3 playerDirection = target.position - transform.position;
        RaycastHit hit;
        if(Physics.Raycast(transform.position, playerDirection, out hit))
        {
            if(hit.transform.tag == "Player")
            {
                playerinVision = true;
            }
            else
            {
                playerinVision = false;
            }
        }
    }
}
