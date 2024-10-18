using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public Vector3 destinationPos;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Ease easeType = Ease.OutExpo;
    public bool isMoving = false;

    #region CustomMethods

    public void MoveDirection(Vector3 direction)
    {
        Vector3 newPosition = transform.position + (direction * 2);
        MovePlayer(newPosition, 0f);
    }


    private void MovePlayer(Vector3 destinationPos, float delayTime)
    {
        StartCoroutine(MoveRoutine(destinationPos, delayTime));
    }

    IEnumerator MoveRoutine(Vector3 destinationPos, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        isMoving = true;
        transform.DOMove(destinationPos, _moveSpeed, false).SetEase(easeType);

        while(Vector3.Distance(destinationPos, transform.position) > 0.01f)
        {
            yield return null;
        }

        transform.position = destinationPos;
        isMoving = false;
    }

    #endregion
}
