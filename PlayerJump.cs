using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    private bool isGrounded;

    //public GameObject ground;
    public Vector3 jump;
    public Rigidbody rb;

    public float jumpSpeed = 2.0f;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0, 2.0f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpSpeed, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter()
    {
        isGrounded = true;
    }
}