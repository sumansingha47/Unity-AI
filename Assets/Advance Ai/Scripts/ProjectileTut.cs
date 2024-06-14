using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTut : MonoBehaviour
{
    public GameObject ImpactVFX;
    private bool collided;
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Player" && !collided)
        {
            collided = true;

            var impact = Instantiate(ImpactVFX, collision.contacts[0].point, Quaternion.identity) as GameObject;

            Destroy(impact, 2);
            
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
