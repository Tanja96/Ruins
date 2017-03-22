using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFlowers : MonoBehaviour {

    public Rigidbody rb;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("JFlower"))
        {
            rb.velocity = new Vector3(0, 10.0f, 0);
        }
    }
}
