using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Movement : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _moveSpeed = 5f;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float _X = Input.GetAxis("Horizontal");
        float _Z = Input.GetAxis("Vertical");

        Vector3 movePosition = transform.right * _X + transform.forward * _Z;
        _characterController?.Move(movePosition * (_moveSpeed * Time.deltaTime));
        
    }
}
