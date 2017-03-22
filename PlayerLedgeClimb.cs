using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLedgeClimb : MonoBehaviour {

    public Rigidbody rb;


    private Vector3 climbPos;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Edge") && rb.position.y <= other.gameObject.transform.position.y)
        {
            rb.velocity = new Vector3(0, 0, 0);
            climbPos = GetComponent<Transform>().position;
            transform.Translate(0, 0.8f, 0.4f);
        }
    }
}
