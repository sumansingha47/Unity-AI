using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTut : MonoBehaviour
{
    private bool collided;
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Player" && !collided)
        {
            collided = true;
            Destroy(gameObject);
        }
    }

//     void TriggerEnter(Collider other)
//     {
//         if(other.gameObject.tag != "Bullet" && other.gameObject.tag != "Player" && !collided)
//         {
//             collided = true;
//             Destroy(gameObject);
//         }
//     }
}
