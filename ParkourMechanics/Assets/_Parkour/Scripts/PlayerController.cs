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

    private Animator _animator;
    private CharacterController _characterController;

    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] Vector3 groundCheckOffset;
    [SerializeField] LayerMask groundLayer;
    private bool isGrounded;
    private float ySpeed;

    private void Awake()
    {
        if (Camera.main != null) _cameraController = Camera.main.GetComponent<CameraController>();
        _animator = transform.GetComponent<Animator>();
        _characterController = transform.GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Input
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        float moveAmount = Mathf.Clamp01(Mathf.Abs(ver) + Mathf.Abs(hor));
        
        // Movement vector
        var moveInput = new Vector3(hor, 0, ver).normalized;
        var moveDirection = _cameraController.PlanarRotation * moveInput;

        GroundCheck();

        if (isGrounded)
        {
            ySpeed = -0.5f;
        }
        else
        {
            ySpeed += Physics.gravity.y * Time.deltaTime;
        }

        // Update velocity
        var velocity = moveDirection * moveSpeed * moveAmount;
        velocity.y = ySpeed;
            
        _characterController.Move(velocity * Time.deltaTime);

        // Handle rotation
        if (moveAmount > 0)
        {
            targetRotation = Quaternion.LookRotation(moveDirection);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
       
        // Update animator
        _animator.SetFloat("moveAmount", moveAmount, 0.2f, Time.deltaTime);
    }

    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(transform.TransformPoint(groundCheckOffset), groundCheckRadius, groundLayer);
    }

    /*private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.TransformPoint(groundCheckOffset), groundCheckRadius);
    }*/
}
