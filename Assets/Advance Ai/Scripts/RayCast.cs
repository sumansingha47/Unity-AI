using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastShoot : MonoBehaviour
{
    public Camera camera;
    public float FireRate = 10f;
    public float timeBetweenNextShot;

    public float Damage = 5f;

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= timeBetweenNextShot) {
            timeBetweenNextShot = Time.time + 1f/FireRate;
            weapon();
        }
    }

    void weapon() {
        RaycastHit hit;
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit)) {
            Debug.Log(hit.transform.name);
            Health enemy = hit.transform.GetComponent<Health>();
            if(enemy != null)
            {
              enemy.Damage(Damage);
            }

        }
    }
    
}
