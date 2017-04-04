using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLedgeClimb : MonoBehaviour {

    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Edge") && CheckHeight(other.transform)) {
            rb.velocity = new Vector3(0, 0, 0);
            transform.Translate(0, 0.8f, 0.4f);
        }
    }
	
	// Tarkistaa pelaajan "jalkojen" korkeuden.
	bool CheckHeight(Transform other) {
		float playerHeight = transform.localScale.y / 5;
		float edgeHeight = other.localScale.y;
		if (transform.position.y - (playerHeight / 2) < other.position.y + (edgeHeight / 2)) {
			if (transform.position.y > other.position.y) {
				return true;
			}
		}
		return false;
	}
}
