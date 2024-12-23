using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float armLength;
    private float _rotationY;
    private float _rotationX;
    [SerializeField] private float minVerticalAngle;
    [SerializeField] private float maxVerticalAngle;
    [SerializeField] private Vector3 framingOffset;
    [SerializeField] private float horizSens;
    [SerializeField] private float verticalSens;
    [SerializeField] private bool invertY;
    private float invertYVal;
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        invertYVal = (invertY) ? -1 : 1;
        
        _rotationY += Input.GetAxis("Mouse X") * horizSens;
        _rotationX += Input.GetAxis("Mouse Y") * verticalSens * invertYVal;
        _rotationX = Mathf.Clamp(_rotationX, minVerticalAngle, maxVerticalAngle);

        var focusPosition = target.position + framingOffset;
        
        var targetRotation = Quaternion.Euler(_rotationX, _rotationY, 0);
        transform.position = focusPosition -  targetRotation * new Vector3(0, 0, armLength);
        transform.rotation = targetRotation;
    }
}
