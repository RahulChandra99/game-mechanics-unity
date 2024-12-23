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
        //hide cursor and lock it
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //check for y inversion
        invertYVal = (invertY) ? -1 : 1;
        
        //horizontal and vertical mouse camera movement
        _rotationY += Input.GetAxis("Camera X") * horizSens;
        _rotationX += Input.GetAxis("Camera Y") * verticalSens * invertYVal;
        //clam vertical camera movement
        _rotationX = Mathf.Clamp(_rotationX, minVerticalAngle, maxVerticalAngle);

        //add offsett to the target's position
        var focusPosition = target.position + framingOffset;
        //get the rotation of the camera following the target
        var targetRotation = Quaternion.Euler(_rotationX, _rotationY, 0);
        //place camera behind the target with the required arm length
        transform.position = focusPosition -  targetRotation * new Vector3(0, 0, armLength);
        //always look at the target by rotating around it
        transform.rotation = targetRotation;
    }

    public Quaternion PlanarRotation => Quaternion.Euler(0, _rotationY, 0);
}
