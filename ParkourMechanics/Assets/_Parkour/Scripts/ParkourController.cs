using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnvironmentScanner))]
public class ParkourController : MonoBehaviour
{
    private EnvironmentScanner _environmentScanner;
    private Animator _animator;
    private PlayerController _playerController;

    [SerializeField] private List<ParkourAction> parkourActions;

    private bool inAction;

    private void Awake()
    {
        _environmentScanner = GetComponent<EnvironmentScanner>();
        _animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetButton("Jump") && !inAction)
        {
            var hitData = _environmentScanner.ObstacleCheck();
            if (hitData.forwardHitFound)
            {
                foreach (var action in parkourActions)
                {
                    if (action.CheckIfPossible(hitData, transform))
                    {
                        StartCoroutine(DoParkourAction(action));
                        break;
                    }
                }
            }
        }
        
        
        
    }

    IEnumerator DoParkourAction(ParkourAction action)
    {
        inAction = true;
        _playerController.SetControl(false);
        
        _animator.CrossFade(action.AnimName,0.2f);
        yield return null;

        var animState = _animator.GetNextAnimatorStateInfo(0);
        if (!animState.IsName(action.AnimName))
            Debug.Log("Parkour animation is wrong!");
        
        yield return new WaitForSeconds(animState.length);

        float timer = 0f;
        while (timer <= animState.length)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        _playerController.SetControl(true);
        inAction = false;
        
    }
}
