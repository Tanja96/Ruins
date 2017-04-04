using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private float speed;
    private bool isGrounded;

    public Rigidbody rb;
    public float walkSpeed = 5f;
    public float runSpeed = 9f;
    public float airSpeed = 3f;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (isGrounded)
        {
            speed = walkSpeed;
            if (Input.GetKey("left shift") && isGrounded && Input.GetAxis("Vertical") >= 0)
            {
                speed = runSpeed;
            }
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 100f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);
        }else
        {
            speed = airSpeed;
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 100f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);
        }
        
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Ground")
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
