using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSShoooterTut : MonoBehaviour
{
    public Camera cam;
    public GameObject projectile;
    public Transform LHFirePoint, RHFirePoint;

    public Vector3 destination;
    private bool leftHand;
    
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            ShootProjectTile();
        }
    }

    void ShootProjectTile()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
            destination = hit.point;
        else
            destination = ray.GetPoint(1000);

        if(leftHand)
        {
            leftHand = false;
            InstantiateProjectile(LHFirePoint);
        }
        else {
            leftHand = true;
            InstantiateProjectile(RHFirePoint);
        }
    }

    void InstantiateProjectile(Transform firePoint)
    {
        var projectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;

    }
}
