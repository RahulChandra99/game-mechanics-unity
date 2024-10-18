using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 1.5f;
    [SerializeField] private Ease easeType = Ease.OutExpo;
    private bool isMoving = false;
    [SerializeField]private GameInput gameInput;

    private void Start()
    {
        gameInput = GetComponent<GameInput>();
    }

    private void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        if (!isMoving)
        {
            // Adjust the input vector to eliminate diagonal movement
            if (Mathf.Abs(inputVector.x) > Mathf.Abs(inputVector.y))
            {
                inputVector.y = 0;
            }
            else
            {
                inputVector.x = 0;
            }

            // Determine the new position based on input vector
            Vector3 newPosition = transform.position + new Vector3(inputVector.x * 2, 0, inputVector.y * 2);

            // Move to the new position if there is any input movement
            if (inputVector != Vector2.zero)
            {
                Move(newPosition, 0f);
            }
        }


    }

    private void Move(Vector3 destinationPos, float delayTime)
    {
        StartCoroutine(MoveRoutine(destinationPos, delayTime));
    }

    IEnumerator MoveRoutine(Vector3 destinationPos,float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        isMoving = true;

        transform.DOMove(destinationPos, moveSpeed, false)
            .SetEase(easeType);

        while(Vector3.Distance(destinationPos,transform.position) > 0.01f)
        {
            yield return null;
        }

        transform.position = destinationPos;
        isMoving = false;
        
    }
}
