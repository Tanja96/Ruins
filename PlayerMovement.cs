﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private float speed;
    private bool isGrounded;
    private Rigidbody rb;
    
    public float walkSpeed = 5f;
    public float runSpeed = 9f;
    public float airSpeed = 3f;
	
	void Start() {
        rb = GetComponent<Rigidbody>();
    }
    
	void Update() {
        if (isGrounded) {
            speed = walkSpeed;
            if (Input.GetKey("left shift") && isGrounded && Input.GetAxis("Vertical") >= 0) {
                speed = runSpeed;
            }
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 100f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);
        } else {
            speed = airSpeed;
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 100f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);
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
