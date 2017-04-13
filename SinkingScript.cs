using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkingScript : MonoBehaviour {

    public float sinkingSpeed = 0.5f;

    private Vector3 originalPos;
    private bool sinking;
    private GameObject player;

	// Use this for initialization
	void Start() {
		originalPos = transform.position;
        sinking = false;
        player = null;
	}
	
	// Update is called once per frame
	void Update() {
        if (!sinking) {
            if (transform.position.y < originalPos.y) {
                transform.Translate(0, sinkingSpeed * Time.deltaTime, 0);
            }
        } else {
            transform.Translate(0, -sinkingSpeed * Time.deltaTime, 0);
            player.transform.Translate(0, -sinkingSpeed * Time.deltaTime, 0);
            CheckUnderWater();
        }
	}
    
    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Player") {
            if (!sinking) {
                player = col.gameObject;
                sinking = true;
            }
        }
    }
    
    void OnCollisionExit(Collision col) {
        if (col.gameObject.tag == "Player") {
            sinking = false;
            player = null;
        }
    }
    
    void CheckUnderWater() {
        if (transform.position.y <= (originalPos.y - transform.localScale.y - 1)) {
            sinking = false;
            player = null;
        }
    }
}
