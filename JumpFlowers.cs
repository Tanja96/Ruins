using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFlowers : MonoBehaviour {

	private PlayerMovement movement;
	private CharacterController controller;
    private bool jumpPressed = false;
    
    public float flowerJumpSpeed = 9f;
    public float flowerBoostJumpSpeed = 11f;
	
    void Start () {
		controller = GetComponent<CharacterController>();
		movement = GetComponent<PlayerMovement>();
    }

    void Update() {
        if (Input.GetButtonUp("Jump"))
            jumpPressed = false;
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("JFlower") && Input.GetButton("Jump") && !jumpPressed) {
			controller.Move(new Vector3(0, 0.1f, 0));
            movement.moveDirection.y = flowerBoostJumpSpeed;
			movement.moveDirection.x = 0;
			movement.moveDirection.z = 0;
            jumpPressed = true;
            
        } else if (other.gameObject.CompareTag("JFlower")) {
			controller.Move(new Vector3(0, 0.1f, 0));
            movement.moveDirection.y = flowerJumpSpeed;
			movement.moveDirection.x = 0;
			movement.moveDirection.z = 0;
            movement.gravity = 16;
        }   
    }
}
