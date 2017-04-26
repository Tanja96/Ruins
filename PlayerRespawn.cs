using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour {

    private Vector3 lastPosition;
    private CharacterController controller;

	void Start () {
        lastPosition = transform.position;
        controller = GetComponent<CharacterController>();	
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		if (controller.velocity.y <= -15) {
			Respawn(lastPosition);
		} else if (hit.collider.gameObject.tag == "Ground") {
			lastPosition = transform.position;
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Death") {
			Respawn(lastPosition);
		}
	}
	
	void Respawn(Vector3 spawnPoint){
		transform.position = spawnPoint;
	}
}
