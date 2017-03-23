using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    private bool isGrounded;

    //public GameObject ground;
    public Rigidbody rb;
    public float jumpSpeed;
    public float jumpVerticalSpeed;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            float forwardDirection = Input.GetAxis("Vertical");
            if (Input.GetKey("left shift") && Input.GetAxis("Vertical") > 0)
            {
                jumpVerticalSpeed = 10.0f;
            }
            else
            {
                jumpVerticalSpeed = 5.0f;
            }
            rb.velocity += jumpSpeed * Vector3.up;
            rb.velocity += forwardDirection * jumpVerticalSpeed * transform.forward;
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionStay(Collision col)
    {
        if(col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}