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
		float playerFeetHeight = transform.position.y;
		float playerNavelHeight = transform.position.y + 1;
		float edgeHeight = other.localScale.y;
		if (playerFeetHeight < other.position.y + (edgeHeight / 2)) {
			if (playerNavelHeight > other.position.y + (edgeHeight / 2)) {
				return true;
			}
		}
		return false;
	}
}
