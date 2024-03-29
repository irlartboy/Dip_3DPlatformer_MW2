﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed = 12f;
    public float walkSpeed = 6f;
    public float gravity = 15f;
    public float jumpHeight = 8f;
    public float boostHeight = 13f;
    public LayerMask groundLayer;
    public float groundRayDistance = 1.1f;



    private CharacterController controller;
    private Vector3 motion;
    private bool isJumping = false;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        bool inputJump = Input.GetButtonDown("Jump");



        Vector3 normalized = new Vector3(inputH, 0f, inputV);
        normalized.Normalize();
        Move(normalized.x, normalized.z);

        // if grounded and pressed jump
        if (IsGrounded() && inputJump)
        {
            Jump(jumpHeight);
        }
        // if is grounded and not jumping 
        if (IsGrounded() && !isJumping)
        {
            motion.y = 0f;
        }

        // if is not grounded and is jumping 
        if (!IsGrounded() && isJumping)
        {
            isJumping = false;
        }
        motion.y += gravity * Time.deltaTime;
        controller.Move(motion * Time.deltaTime);
    }

    private bool IsGrounded()
    {
        Ray groundRay = new Ray(transform.position, -transform.up);
        if (Physics.Raycast(groundRay, groundRayDistance, groundLayer))
        {
            return true; 
        }
        return false; 
    }

    public void Move(float horizontal, float vertical)
    {
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        direction = transform.TransformDirection(direction);

        motion.x = direction.x * walkSpeed;
        motion.z = direction.z * walkSpeed;


        /* Don't use this because it can not be called for another mechanic like a jump pad
         if (Input.GetButton("Jump"))
         {
             direction.y = jumpHeight;
         } */

        if (IsGrounded() && Input.GetKey(KeyCode.LeftShift))
        {
            motion.x = direction.x * runSpeed;
            motion.z = direction.z * runSpeed;
        }
        if (IsGrounded() && Input.GetMouseButton(1))
        {
            motion = direction * boostHeight;
        }
    }

    public void Jump(float height)
    {
        motion.y = height;
        isJumping = true;
    }
   
}
