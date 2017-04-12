using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour {

    private Vector3 lastPosition;
    private Rigidbody rb;

	void Start () {
        lastPosition = transform.position;
        rb = GetComponent<Rigidbody>();	
	}

	void OnCollisionEnter(Collision col) {
		foreach (ContactPoint contact in col.contacts) {
				if (contact.point.y <= transform.position.y) {
					if (col.relativeVelocity.magnitude > 15) {
						Respawn(lastPosition);
					}
				}
			}
	}
	
    void OnCollisionStay(Collision col) {
        if (col.gameObject.tag == "Ground") {
			foreach (ContactPoint contact in col.contacts) {
				if (contact.point.y <= transform.position.y) {
					lastPosition = transform.position;
				}
			}
		}
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Death") {
            Respawn(lastPosition);
        }
    }
	
	void Respawn(Vector3 spawnPoint){
		rb.velocity = new Vector3(0, 0, 0);
		transform.position = spawnPoint;
	}
}
