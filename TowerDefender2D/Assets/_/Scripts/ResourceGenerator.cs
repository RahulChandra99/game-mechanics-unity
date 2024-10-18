using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    private float timer;
    private float timerMax;
    private BuildingTypeSO buildingType;

    private void Awake()
    {
        
        buildingType = GetComponent<BuildingTypeHolder>().BuildingTypeSo;
        timerMax = buildingType.resourceGeneratorData.timerMax;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer += timerMax;
            Debug.Log("Ding" + buildingType.resourceGeneratorData.ResourceTypeSo.nameString);
        }
    }
    
}
