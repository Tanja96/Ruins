using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFlowers : MonoBehaviour {

	private PlayerMovement movement;
	private CharacterController controller;
    
    public float flowerJumpSpeed = 9f;
    public float flowerBoostJumpSpeed = 11f;
	
    void Start () {
		controller = GetComponent<CharacterController>();
		movement = GetComponent<PlayerMovement>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("JFlower") && Input.GetButton("Jump")) {
			controller.Move(new Vector3(0, 0.1f, 0));
            movement.moveDirection.y = flowerBoostJumpSpeed;
			movement.moveDirection.x = 0;
			movement.moveDirection.z = 0;
        } else if (other.gameObject.CompareTag("JFlower")) {
			controller.Move(new Vector3(0, 0.1f, 0));
            movement.moveDirection.y = flowerJumpSpeed;
			movement.moveDirection.x = 0;
			movement.moveDirection.z = 0;
        }   
    }
}
