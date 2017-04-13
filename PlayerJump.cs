using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    private Rigidbody rb;
    private bool isGrounded;
	
    public float jumpSpeed;
    public float jumpVerticalSpeed;

    void Start() {
        rb = GetComponent<Rigidbody>();
	    jumpVerticalSpeed = 5f;
    }

    void Update() {
        if (Input.GetButtonDown("Jump") && isGrounded && Time.timeScale == 1) {
            float forwardDirection = Input.GetAxis("Vertical");
            if (Input.GetKey("left shift") && Input.GetAxis("Vertical") > 0) {
                jumpVerticalSpeed = 10f;
            } else {
                jumpVerticalSpeed = 5f;
            }
            rb.velocity += jumpSpeed * Vector3.up;
            rb.velocity += forwardDirection * jumpVerticalSpeed * transform.forward;
            isGrounded = false;
        }
    }

    void OnCollisionStay(Collision col) {
        foreach (ContactPoint contact in col.contacts) {
            if (contact.point.y <= (transform.position.y + 0.2f)) {
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
