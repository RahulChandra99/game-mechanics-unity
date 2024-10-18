using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMover))]
public class PlayerManager : MonoBehaviour
{
    public PlayerMover playerMover;
    public PlayerInput playerInput;

    private void Awake()
    {
        playerMover = GetComponent<PlayerMover>();
        playerInput = GetComponent<PlayerInput>();
        playerInput.InputEnabled = true;
    }

    private void Update()
    {
        if (playerMover.isMoving)
            return;

        playerInput.GetInput();

        if(playerInput.H == 0 )
        {
            if (playerInput.V > 0)
                playerMover.MoveDirection(Vector3.forward);
            else if (playerInput.V < 0)
                playerMover.MoveDirection(Vector3.back);
        }
        else if (playerInput.V == 0)
        {
            if (playerInput.H > 0)
                playerMover.MoveDirection(Vector3.right);
            else if (playerInput.H < 0)
                playerMover.MoveDirection(Vector3.left);

        }
    }


}
