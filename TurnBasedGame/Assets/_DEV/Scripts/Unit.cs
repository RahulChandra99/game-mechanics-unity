using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Unit : MonoBehaviour
{
    // Speed at which the unit moves
    private float moveSpeed = 3f;
    // Target position the unit will move towards
    private Vector3 targetPos;
    [SerializeField]private Animator unitAnimator;

    private void Update()
    {
        
        // Define a minimum stopping distance from the target position
        float stoppingDistance = 0.01f;

        // Check if the unit is farther from the target than the stopping distance
        if (Vector3.Distance(transform.position, targetPos) > stoppingDistance)
        {
            // Calculate the direction towards the target position and normalize it
            Vector3 moveDirection = (targetPos - transform.position).normalized;

            // Move the unit towards the target based on the direction, speed, and deltaTime
            transform.position += moveDirection * Time.deltaTime * moveSpeed;

            float rotateSpeed = 10.0f;
            transform.forward = Vector3.Lerp(transform.forward, moveDirection,rotateSpeed * Time.deltaTime);
            unitAnimator.SetBool("IsWalking",true);
        }
        else
        {
            unitAnimator.SetBool("IsWalking",false);
        }
            
        // Check for a left mouse button click to set a new target position
        if (Input.GetMouseButtonDown(0))
        {
            // Call the Move function with the mouse world position as the new target position
            Move(MouseWorld.GetMousePosition());
            
        }
    }

    // Function to set the target position for the unit to move towards
    private void Move(Vector3 targetPosition)
    {
        this.targetPos = targetPosition;
    }
}