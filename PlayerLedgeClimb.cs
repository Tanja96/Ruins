using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLedgeClimb : MonoBehaviour {

    public Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Edge"))
        {
            rb.velocity = new Vector3(0, 0, 0);
            transform.Translate(0, 0.8f, 0.4f);

        }
    }
}
