using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform followTarget;
    [SerializeField] private float distToCamera = 5f;
    private float _rotationY,_rotationX;
    [SerializeField] private float rotationSpeed = 2;
    [SerializeField] private float minVerticalAngle = -45;
    [SerializeField] private float maxVerticalAngle = 45;
    [SerializeField] private Vector2 framingOffset;
    [SerializeField] private bool invertX, invertY;
    
    

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float invertXVal = (invertX) ? -1 : 1;
        float invertYVal = (invertY) ? -1 : 1;
        
        _rotationY += Input.GetAxis("Camera X") * rotationSpeed * invertXVal;
        _rotationX += Input.GetAxis("Camera Y") * rotationSpeed * invertYVal;
        _rotationX = Mathf.Clamp(_rotationX, minVerticalAngle, maxVerticalAngle);
        var targetRotation = Quaternion.Euler(_rotationX , _rotationY , 0) ;
        
        var focusPosition = followTarget.position + new Vector3(framingOffset.x, framingOffset.y);
        
        //place camera behind the player and rotate around it
        transform.position = focusPosition -  targetRotation * new Vector3(0, 0, distToCamera);
        //camera look at player
        transform.rotation = targetRotation;


    }

    //property
    public Quaternion PlanarRotation => Quaternion.Euler(0, _rotationY, 0);
}
