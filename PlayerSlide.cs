using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlide : MonoBehaviour {

	public float slideSpeed = 6.0f;
	public float forwardJumpSpeed = 6.0f;
	public float jumpHeight = 2.0f;
	
	public Rigidbody rb;

	private bool sliding = false;
	private bool isGrounded;
	
	// Update is called once per frame
	void Update () {
		
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
	
	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Ground") {
			isGrounded = true;
		}
	}
	
	void OnCollisionExit(Collision col) {
		if (col.gameObject.tag == "Ground") {
			isGrounded = false;
		}
	}
}
