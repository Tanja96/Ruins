using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeScript : MonoBehaviour {

	public Camera fixedCam;
	
	private GameObject player;
	private Camera playerCam;
	private float heightOffset;
	
	void Start() {
		fixedCam.gameObject.active = false;
	}
	
	void Update() {
		if (fixedCam.gameObject.active) {
			fixedCam.transform.LookAt(player.transform);
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			player = other.gameObject;
			playerCam = player.transform.GetChild(2).GetComponent<Camera>();
			fixedCam.gameObject.active = true;
			playerCam.gameObject.active = false;
			heightOffset = fixedCam.transform.position.y - player.transform.position.y;
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") {
			fixedCam.gameObject.active = false;
			playerCam.gameObject.active = true;
		}
	}
	
}
