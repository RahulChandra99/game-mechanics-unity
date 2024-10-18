using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public Camera playerCam;
    public float fireRate;
    public float range = 100;
    private float nextFire = 0;
    public ParticleSystem muzzleFlash;
    public GameObject bulletImpact;

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFire)
        {
            nextFire = Time.time + 1 / fireRate;
            muzzleFlash.Play();

            RaycastHit hit;
            if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range))
            {
                Instantiate(bulletImpact, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
    }
}
