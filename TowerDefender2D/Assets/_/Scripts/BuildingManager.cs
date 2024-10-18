using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    private Camera _mainCamera;
    private BuildingTypeSO buildingTypeSo;
    private BuildingTypeListSO buildingTypeListSo;

    private void Awake()
    {
        buildingTypeListSo = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
        buildingTypeSo = buildingTypeListSo.list[0];
    }

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(buildingTypeSo.pfBuildingType, GetMouseWorldPosition(), Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            buildingTypeSo = buildingTypeListSo.list[0];
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            buildingTypeSo = buildingTypeListSo.list[1];
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        return mousePosition;
    }
}
