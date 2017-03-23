using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour {

	public Rigidbody rb;
	public float hangJumpSpeed = 8.0f;
	public float hangJumpVerticalSpeed = 5.0f;
	public float hangJumpHorizontalSpeed = 4.0f;
	
	private bool hanging = false;
	
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
	
	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Ledge") {
			if (Input.GetKey("mouse 0")) {
				GrabLedge(col.transform);
			}
		}
	}
	
	void OnCollisionStay(Collision col) {
		if (col.gameObject.tag == "Ledge") {
			if (!Input.GetKey("mouse 0")) {
				UngrabLedge();
			}
		}
	}
	
	void OnCollisionExit(Collision col) {
		if (col.gameObject.tag == "Ledge") {
			UngrabLedge();
		}
	}
	
	void GrabLedge(Transform ledge) {
		
		Debug.Log("Grabbed");
		
		//Move character's hands to same height as the ledge.
		float playerHeight = transform.position.y + (transform.localScale.y / 2);
		float ledgeHeight = ledge.position.y + (ledge.localScale.y / 2);
		float distToLedge = playerHeight - ledgeHeight;
		transform.Translate(0, -distToLedge, 0);
		Vector3 euler = ledge.rotation.eulerAngles;  
        Quaternion rot = Quaternion.Euler(0, euler.y, 0);
        transform.rotation = rot;
		
		rb.velocity = new Vector3(0, 0, 0);
		rb.useGravity = false;
		rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePosition;
		hanging = true;
	}
	
	void UngrabLedge() {
		Debug.Log("Ungrabbed");
		rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		rb.useGravity = true;
		hanging = false;
	}
}
