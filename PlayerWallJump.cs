using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJump : MonoBehaviour {

//    private PlayerMovement pm;

//    private CharacterController controller;
//    private Vector3 moveVector;
//    private Vector3 lastMove;
//    private float moveZ;
//    private float wallJumpSpeedUp = 10f;
//    private float wallJumpSpeedForward = 5f;
//    private float gravity = 15f;
//    private float verticalVelocity;
//    private float rotate;

//    Use this for initialization

//   void Start()
//    {
//        controller = GetComponent<CharacterController>();
//    }

//    Update is called once per frame
//    void Update() {
//        moveZ = Input.GetAxis("Vertical");
//        moveVector = Vector3.zero;
//        rotate = Input.GetAxis("Horizontal");
//        moveVector = transform.forward * moveZ;

//        if (controller.isGrounded) {
//            verticalVelocity = -1;
//            if (Input.GetButtonDown("Jump")) {
//                verticalVelocity = wallJumpSpeedUp;
//            }
//        } else {
//            verticalVelocity -= gravity * Time.deltaTime;
//            moveVector = lastMove;
//        }

//        moveVector.y = 0;
//        moveVector.Normalize();
//        moveVector *= wallJumpSpeedForward;
//        moveVector.y = verticalVelocity;

//        controller.Move(moveVector * Time.deltaTime);
//        transform.Rotate(0, rotate * 5f, 0);
//        lastMove = moveVector;
//    }

//    private void OnControllerColliderHit(ControllerColliderHit col) {
//        if (!controller.isGrounded && col.normal.y < 0.3f && Input.GetButton("Jump")) {
//            Debug.DrawRay(col.point, col.normal, Color.white, 1.25f);
//            pm.moveDirection.y = wallJumpSpeedUp; //verticalVelocity
//            pm.moveDirection = col.normal * wallJumpSpeedForward; //moveVector
//            transform.rotation = Quaternion.LookRotation(-col.normal);
//            transform.Rotate(0, 180, 0);
//        }
//    }
}

//moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
//			moveDirection = transform.TransformDirection(moveDirection);
//			moveDirection *= speed;

//moveDirection.y -= gravity* Time.deltaTime;
//controller.Move(moveDirection* Time.deltaTime);
//rotation = Input.GetAxis("Horizontal");
//		transform.Rotate(0, rotation, 0);
