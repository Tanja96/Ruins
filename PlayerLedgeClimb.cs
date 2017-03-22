using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLedgeClimb : MonoBehaviour {

    public Rigidbody rb;
    //public float speed = 0.00001F;
    public Transform startMarker;
    public Transform endMarker;

    private float startTime;
    private float journeyLength;
    private Vector3 climbPos;
    private Vector3 endPos;
    private bool lerp = false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        startTime = Time.time;
        journeyLength = Vector3.Distance(climbPos, endPos);
    }
	
	// Update is called once per frame
	void Update () {
        
        if (lerp)
        {
            float distCovered = (Time.time - startTime);
            float fracJourney = distCovered / 1.0f;
            transform.position = Vector3.Lerp(climbPos, endPos, fracJourney);
            //transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
            if (fracJourney >= 1.0f)
            {
                lerp = false;
            }
        }
        
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Edge") && rb.position.y <= other.gameObject.transform.position.y)
        {
            rb.velocity = new Vector3(0, 0, 0);
            climbPos = GetComponent<Transform>().position;
            transform.Translate(0, 0.8f, 0.4f); // 0, 4f, 3f
            endPos = GetComponent<Transform>().position;
            startMarker.position = climbPos;
            endMarker.position = endPos;
            lerp = true;
        }
    }
}
