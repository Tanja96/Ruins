using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour {
	
	private Rigidbody rb;
	private Collider lastCollider;
	private bool hanging;
    
    public float hangJumpSpeed = 10.0f;
	public float hangJumpVerticalSpeed = 3.0f;
	public float hangJumpHorizontalSpeed = 4.0f;
	
	void Start() {
        rb = GetComponent<Rigidbody>();
		lastCollider = null;
        hanging = false;
    }
	
	void Update() {
		if (hanging) {
			if (!Input.GetKey("mouse 0")) {
				UngrabLedge();
			}
			if (Input.GetButtonDown("Jump")) {			
				if (Input.GetAxis("Vertical") < 0) {
					UngrabLedge();
					rb.velocity += hangJumpSpeed * Vector3.up;
					rb.velocity += hangJumpVerticalSpeed * -transform.forward;
					transform.Rotate(0, 180f, 0);
				} else if (Input.GetAxis("Vertical") > 0) {
					UngrabLedge();
					rb.velocity += hangJumpSpeed * Vector3.up;
				}  else if (Input.GetAxis("Horizontal") < 0) {
					UngrabLedge();
					rb.velocity += (hangJumpSpeed / 2) * Vector3.up;
					rb.velocity += hangJumpHorizontalSpeed * -transform.right;
				}  else if (Input.GetAxis("Horizontal") > 0) {
					UngrabLedge();
					rb.velocity += (hangJumpSpeed / 2) * Vector3.up;
					rb.velocity += hangJumpHorizontalSpeed * transform.right;
				}
			}
			var x = Input.GetAxis("Horizontal") * Time.deltaTime * 3f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 3f;

            transform.Translate(-x, 0, -z);
		}
	}
	
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Ledge") {
			if (Input.GetKey("mouse 0") && transform.position.y < col.transform.position.y) {
				lastCollider = col;
				GrabLedge(col.transform);
			}
		}
	}
	
	void OnTriggerStay(Collider col) {
		if (col.gameObject.tag == "Ledge") {
			if (!Input.GetKey("mouse 0")) {
				UngrabLedge();
			} else if (col != lastCollider && transform.position.y < col.transform.position.y) {
				lastCollider = col;
				GrabLedge(col.transform);
			}
		}
	}
	
	void OnTriggerExit(Collider col) {
		if (col.gameObject.tag == "Ledge") {
			UngrabLedge();
		}
	}
	
	void GrabLedge(Transform ledge) {	
		//Move character's hands to same height as the ledge.
		float playerHeight = transform.position.y + (transform.localScale.y / 10);
		float ledgeHeight = ledge.position.y + (ledge.localScale.y / 2);
		float distToLedge = playerHeight - ledgeHeight;
		transform.Translate(0, -distToLedge, 0);
		
		rb.velocity = new Vector3(0, 0, 0);
		rb.useGravity = false;
		rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePosition;
		hanging = true;
	}
	
	void UngrabLedge() {
		rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		rb.useGravity = true;
		hanging = false;
	}
}
