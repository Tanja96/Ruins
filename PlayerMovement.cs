using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private float speed;
    private bool isGrounded;
    private Rigidbody rb;
    
    public float walkSpeed = 5f;
    public float runSpeed = 9f;
    public float airSpeed = 3f;
    public Animator animator;
	
	void Start() {
        rb = GetComponent<Rigidbody>();
    }
    
	void Update() {
        if (Input.GetAxis("Vertical") != 0) {
            animator.SetBool("Run", true);
        } else {
            animator.SetBool("Run", false);
        }
        if (isGrounded) {
            speed = walkSpeed;
            if (Input.GetKey("left shift") && isGrounded && Input.GetAxis("Vertical") >= 0) {
                speed = runSpeed;
                animator.SetBool("FastRun", true);
            }
            else
            {
                animator.SetBool("FastRun", false);
            }
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 100f;
            var z = Input.GetAxis("Vertical") * speed;

            transform.Rotate(0, x, 0);
			//rb.MovePosition(transform.position + transform.forward * z);
			rb.velocity = transform.forward * z;
        } else {
            speed = airSpeed;
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 100f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

            transform.Rotate(0, x, 0);
			rb.MovePosition(transform.position + transform.forward * z);
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
