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
                StartCoroutine(DoParkourAction());
            }
        }
        
        
        
    }

    IEnumerator DoParkourAction()
    {
        inAction = true;
        _playerController.SetControl(false);
        
        _animator.CrossFade("StepUp",0.2f);
        yield return null;

        var animState = _animator.GetNextAnimatorStateInfo(0);
        Debug.Log(animState.length);
        
        yield return new WaitForSeconds(animState.length);

        _playerController.SetControl(true);
        inAction = false;
        
    }
}
