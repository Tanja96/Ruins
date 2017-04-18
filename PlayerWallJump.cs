using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJump : MonoBehaviour {

    private Rigidbody rb;

    public float wallJumpSpeed = 10.0f;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        float t = Time.time;
        if(col.gameObject.CompareTag("Ground") && Input.GetButton("Jump")){
            rb.velocity = new Vector3(0, 0, 0);
            if(Time.time < t + 3)
            {
                rb.velocity += wallJumpSpeed * Vector3.up;
                rb.velocity += wallJumpSpeed / 2 * vector3.back;
            }
            else
            {
                rb.velocity += wallJumpSpeed / 5 * Vector3.down;
            }
        }
    }
}
