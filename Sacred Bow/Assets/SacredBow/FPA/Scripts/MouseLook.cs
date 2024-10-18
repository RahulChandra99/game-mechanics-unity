using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPA
{
    public class MouseLook : MonoBehaviour
    {
        public float mouseSens = 100f;

        public Transform playerBody;

        private float xRotation = 0f;
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {

            float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);  //restricting mouse look movemnt along y axis

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }

}
