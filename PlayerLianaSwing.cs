using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLianaSwing : MonoBehaviour {

    private Rigidbody rb;
    private bool swinging;
    private Transform curLiana;
    
    public float rotateSpeed = 3f;
    public float climbSpeed = 0.5f;

	void Start() {
		rb = GetComponent<Rigidbody>();
        swinging = false;
        curLiana = null;
	}
	
	void Update() {      
        if (swinging) {
            float rotation = Input.GetAxis("Horizontal");
            float climbDirection = Input.GetAxis("Vertical");
            transform.RotateAround(curLiana.position, Vector3.up, rotation * rotateSpeed);
            transform.Translate(0, climbDirection * climbSpeed * Time.deltaTime, 0);
        }	
	}
    
    void OnTriggerStay(Collider col) {
        if (col.gameObject.tag == "Liana") {
            if (Input.GetKey("mouse 0")) {
                if (!swinging) {
                    GrabLiana(col.gameObject.transform);
                }
            } else {
                if (swinging) {
                    UngrabLiana(6f);
                }
            }
        }
    }
    
    void OnTriggerExit(Collider col) {
        if (col.gameObject.tag == "Liana") {
            if (swinging) {
                UngrabLiana(0);
            }
        }
    }
    
    void GrabLiana(Transform liana) {
        curLiana = liana;
        rb.velocity = new Vector3(0, 0, 0);
		rb.useGravity = false;
        GetComponent<PlayerMovement>().enabled = false;
        swinging = true;
    }
    
    void UngrabLiana(float forwardSpeed) {
        curLiana = null;
        GetComponent<PlayerMovement>().enabled = true;
        rb.useGravity = true;
        rb.velocity += forwardSpeed * transform.forward;
        rb.velocity += 4f * Vector3.up;
        swinging = false;
    }
}
