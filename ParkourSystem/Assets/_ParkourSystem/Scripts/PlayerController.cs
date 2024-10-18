using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement speed of the player
    [SerializeField] private float moveSpeed = 5f;
    
    // Reference to the CameraController script
    private CameraController _cameraController;

    // Player rotation
    private Quaternion targetRotation;
    [SerializeField] private float playerRotationSpeed = 500f;

    // Animator and CharacterController components
    private Animator _animator;
    private CharacterController _characterController;

    // Ground check settings
    [Header("GroundCheck Settings")]
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private Vector3 groundCheckOffset;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;
    private float ySpeed;

    private void Awake()
    {
        // Initialize CameraController if the main camera exists
        if (Camera.main != null) 
            _cameraController = Camera.main.GetComponent<CameraController>();

        // Get Animator and CharacterController components
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Get input from player
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        
        // Create a movement vector based on input
        Vector3 moveInput = new Vector3(h, 0, v).normalized;
        
        // Calculate movement amount
        float moveAmount = Mathf.Clamp01(Mathf.Abs(h) + Mathf.Abs(v));
        
        // Adjust movement direction based on camera rotation
        var moveDir = _cameraController.PlanarRotation * moveInput;

        // Check if player is grounded
        GroundCheck();
        
        // Handle vertical movement (gravity)
        if (isGrounded)
        {
            ySpeed = -0.5f; // Small downward force to keep player grounded
        }
        else
        {
            ySpeed += Physics.gravity.y * Time.deltaTime; // Apply gravity
        }

        // Calculate final velocity
        var velocity = moveDir * moveSpeed;
        velocity.y = ySpeed;

        // Move the character controller
        _characterController.Move(velocity * Time.deltaTime);

        // Rotate the player if there is movement
        if (moveAmount > 0)
        {
            targetRotation = Quaternion.LookRotation(moveDir); // Face movement direction
        }
        
        // Smoothly rotate player towards the target direction
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, playerRotationSpeed * Time.deltaTime);

        // Update the animator with the movement amount
        _animator.SetFloat("moveAmount", moveAmount, 0.2f, Time.deltaTime);
    }

    // Check if the player is on the ground
    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(transform.TransformPoint(groundCheckOffset), groundCheckRadius, groundLayer);
    }

    // Draw gizmos in the editor to visualize ground check
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.TransformPoint(groundCheckOffset), groundCheckRadius);
    }
}
