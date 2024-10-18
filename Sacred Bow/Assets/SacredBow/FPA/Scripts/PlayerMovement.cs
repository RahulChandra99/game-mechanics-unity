using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPA
{
    public class PlayerMovement : MonoBehaviour
    {

        public float walkSpeed = 5f;
        private float speed;
        public float runSpeed = 10f;

        public static bool canMove = true;

        public CharacterController controller;

        Vector3 velocity;

        public float gravity = -9.81f;

        public Transform groundCheck;
        public float groundDistance = 0.4f;
        public LayerMask groundMask;

        bool isGrounded;

        

        private void Start()
        {
            
        }

        void Update()
        {
            

            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if(isGrounded && velocity.y <0)
            {
                velocity.y = -2f;
            }

            if (canMove == true)
            {
                

                float x = Input.GetAxis("Horizontal");
                float z = Input.GetAxis("Vertical");

                Vector3 move = transform.right * x + transform.forward * z;


                if (Input.GetKey(KeyCode.LeftShift))
                {
                    speed = runSpeed;
                }
                else
                    speed = walkSpeed;

                controller.Move(move * speed * Time.deltaTime);

                velocity.y += gravity * Time.deltaTime;

                controller.Move(velocity * Time.deltaTime);
            }
            

        }
    }
}

