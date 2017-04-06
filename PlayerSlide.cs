using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlide : MonoBehaviour {

    private Rigidbody rb;
	private bool sliding;
	private bool isGrounded;

	public float slideSpeed = 6.0f;
	public float forwardJumpSpeed = 6.0f;
	public float jumpHeight = 2.0f;
	
    void Start() {
        rb = GetComponent<Rigidbody>();
        sliding = false;
    }
    
	void Update() {
		
		if (sliding) {
			//transform.Translate(0, 0, slideSpeed);
		}
		
		if (Input.GetKeyDown("left ctrl") && isGrounded) {
			if (!sliding) {
				rb.velocity += jumpHeight * Vector3.up;
				rb.velocity += forwardJumpSpeed * transform.forward;
				transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 3, transform.localScale.z);			
				sliding = true;
			}
		}
		if (Input.GetKeyUp("left ctrl")) {
			if (sliding) {
				transform.Translate(0, 2, 0);
				transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 3, transform.localScale.z);
				sliding = false;
			}
		}
	}
	
	void OnCollisionStay(Collision col) {
	    foreach (ContactPoint contact in col.contacts) {
		    if (contact.point.y <= (transform.position.y - 1.2f)) {
			    isGrounded = true;
			} else {
			    isGrounded = false;
		    }
	    }
    }
	
	void OnCollisionExit(Collision col) {
		isGrounded = false;
	}
}
