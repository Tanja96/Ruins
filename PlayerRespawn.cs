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

    void OnCollisionExit(Collision col) {
        if (col.gameObject.tag == "Ground") {
            lastPosition = transform.position;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Death") {
            rb.velocity = new Vector3(0, 0, 0);
            transform.position = lastPosition;
        }
    }
}
