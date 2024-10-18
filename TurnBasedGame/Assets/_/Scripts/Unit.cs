using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Unit : MonoBehaviour
{
    private float moveSpeed = 3f;
    private Vector3 targetPos;

    private void Update()
    {
        

        float stoppingDistance = 0.01f;
        if (Vector3.Distance(transform.position, targetPos) > stoppingDistance)
        {
            Vector3 moveDirection = (targetPos - transform.position).normalized;
            transform.position += moveDirection * Time.deltaTime * moveSpeed;
        }
            
        if(Input.GetMouseButtonDown(0))
        {
            Move(MouseWorld.GetMousePosition());
        }
    }

    private void Move(Vector3 targetPosition)
    {
        this.targetPos = targetPosition;
    }
}
