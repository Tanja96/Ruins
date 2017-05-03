using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLedgeClimb : MonoBehaviour {

    private CharacterController controller;
    private bool beenHit = false;
    private float startTime;
    private float journeyLength;

    public Vector3 startPos;
    public Vector3 endPos;
    public float speed = 1.5f;

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        //startTime = Time.time;
    }

    void Update() {
        if (beenHit) {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startPos, endPos, fracJourney);
            if (transform.position == endPos)
                beenHit = false;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Edge") && CheckHeight(other.transform)) {
            startTime = Time.time;
            startPos = transform.position;
            endPos = startPos + new Vector3(0, 1.5f, 2f);
            journeyLength = Vector3.Distance(startPos, endPos);
            //Vector3 playerVelocity = controller.velocity;
            //playerVelocity = new Vector3(0, 0, 0);
            beenHit = true;
        }
    }

    // Tarkistaa pelaajan "jalkojen" korkeuden.
    bool CheckHeight(Transform other) {
		float playerFeetHeight = transform.position.y;
		float playerNavelHeight = transform.position.y + 1;
		float edgeHeight = other.localScale.y;
		if (playerFeetHeight < other.position.y + (edgeHeight / 2)) {
			if (playerNavelHeight > other.position.y + (edgeHeight / 2)) {
				return false;
			}
		}
		return true;
	}
}
