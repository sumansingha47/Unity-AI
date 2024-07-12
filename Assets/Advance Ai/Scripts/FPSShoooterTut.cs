using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSShoooterTut : MonoBehaviour
{
    public Camera cam;
    public GameObject projectile;
    public GameObject muzzle;
    public Transform LHFirePoint, RHFirePoint;
    public float projectileSpeed = 30;
    public float fireRate = 4;
    public float arcRange = 1;

    private Vector3 destination;
    private bool leftHand;
    private float timeToFire;


    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1/fireRate;
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
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;

        iTween.PunchPosition(projectileObj, new Vector3(Random.Range(-arcRange, arcRange), Random.Range(-arcRange, arcRange), 0), Random.Range(0.5f, 2));

        var muzzleObj = Instantiate(muzzle, firePoint.position, Quaternion.identity) as GameObject;
        Destroy(muzzleObj, 2);

    }
}
