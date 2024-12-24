using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnvironmentScanner))]
public class ParkourController : MonoBehaviour
{
    private EnvironmentScanner _environmentScanner;

    private void Awake()
    {
        _environmentScanner = GetComponent<EnvironmentScanner>();
    }

    private void Update()
    {
       var hitData = _environmentScanner.ObstacleCheck();
       if (hitData.forwardHitFound)
       {
           Debug.Log("Obstacle Found" + hitData.forwardHit.transform.name);
       }
    }
}
