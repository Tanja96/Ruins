using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFlowers : MonoBehaviour {

    private Rigidbody rb;
    
    public float flowerJumpSpeed = 9f;
    public float flowerBoostJumpSpeed = 11f;
	
    void Start () {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("JFlower") && Input.GetButton("Jump")) {
            rb.velocity = new Vector3(0, flowerBoostJumpSpeed, 0);
        } else if (other.gameObject.CompareTag("JFlower")) {
            rb.velocity = new Vector3(0, flowerJumpSpeed, 0);
        }   
    }
}
