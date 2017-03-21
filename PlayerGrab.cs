using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour {

	public Rigidbody rb;
	
	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Ledge") {
			if (Input.GetKey("mouse 0")) {
				GrabLedge();
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
	
	void GrabLedge() {
		Debug.Log("Grabbed");
		rb.velocity = new Vector3(0, 0, 0);
		rb.useGravity = false;
		rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
	}
	
	void UngrabLedge() {
		Debug.Log("Ungrabbed");
		rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		rb.useGravity = true;
	}
}
