using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private float speed;
    private bool isGrounded;

    public float walkSpeed;
    public float runSpeed;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        speed = walkSpeed;

        if (Input.GetKey("left shift") && isGrounded && Input.GetAxis("Vertical") >= 0)
        {
            speed = runSpeed;
        }
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 100f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }
    void OnCollisionEnter()
    {
        isGrounded = true;
    }
    void OnCollisionExit()
    {
        isGrounded = false;
    }
}
