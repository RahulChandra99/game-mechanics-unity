using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CameraController _cameraController;
    public float moveSpeed = 5;
    public float rotationSpeed = 500f;
    private Quaternion targetRotation;

    private void Awake()
    {
        if (Camera.main != null) _cameraController = Camera.main.GetComponent<CameraController>();
    }

    private void Update()
    {
        //take input
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        float moveAmount = Mathf.Abs(ver) + Mathf.Abs(hor);
        
        //make vector with input
        var moveInput = new Vector3(hor, 0, ver).normalized;
        //multiply move vector with camera rotataion and create movedirection vector
        var moveDirection = _cameraController.PlanarRotation * moveInput;

        if (moveAmount > 0)
        {
            //change position with the new vector created and multiply by speed and with time.deltatime
            transform.position += moveDirection * (moveSpeed * Time.deltaTime);
            
            //make character face the direction its moving in
            targetRotation = Quaternion.LookRotation(moveDirection);
            //smoothly rotate and set value
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
       

    }
}
