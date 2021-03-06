﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private bool canJump = true;
    private float speed;
    private float rotation;
    private CharacterController controller;

    public Vector3 moveDirection = Vector3.zero;
    public float walkSpeed = 5f;
    public float runSpeed = 9f;
    private float airSpeed = 5; //10f
    public float gravity = 15f;
    public float jumpSpeed = 7f;
    public float wallJumpSpeedUp = 10f;
    public float wallJumpSpeedForward = 5f;
    public Animator animator;

    void Start() {
        controller = GetComponent<CharacterController>();
    }

    void Update() {
        if (controller.isGrounded) {
            gravity = 25;
        }
        Debug.Log(controller.velocity.y);
        if (Input.GetAxis("Vertical") != 0) {
            animator.SetBool("Run", true);
        } else {
            animator.SetBool("Run", false);
        }
        if (controller.isGrounded) {
            speed = walkSpeed;
            if (Input.GetKey("left shift") && Input.GetAxis("Vertical") >= 0) {
                speed = runSpeed;
                animator.SetBool("FastRun", true);
            } else {
                animator.SetBool("FastRun", false);
            }
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButtonDown("Jump") && canJump) {
                moveDirection.y = jumpSpeed;
            }
        } else {
            if (controller.velocity.magnitude < 0.1f)
                airSpeed = 20f;
            else
                airSpeed = 5f;
            moveDirection += Input.GetAxis("Vertical") * airSpeed * transform.forward * Time.deltaTime; //
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        rotation = Input.GetAxis("Horizontal") * 2;
        transform.Rotate(0, rotation, 0);
    }

    private void OnControllerColliderHit(ControllerColliderHit col) {
        //Jump between walls
        if (!controller.isGrounded && col.normal.y < 0.05f && col.normal.y > -0.05f && Input.GetButtonDown("Jump") && col.gameObject.CompareTag("JumpWall")) {
            Debug.DrawRay(col.point, col.normal, Color.white, 1.25f);
            transform.rotation = Quaternion.LookRotation(-col.normal);
            transform.Rotate(0, 180, 0);
            moveDirection = col.normal * wallJumpSpeedForward;
            moveDirection.y = wallJumpSpeedUp;
        }
        //Walls
        if (col.normal.y < 0.6f && col.normal.y > -0.6f && col.gameObject.CompareTag("Ground")) {
            Debug.DrawRay(col.point, col.normal, Color.white, 1.25f);
            moveDirection = col.normal * 3f;
            moveDirection.y = -3f;
            canJump = false;
        } else
            canJump = true;
    }
}
