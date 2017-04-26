using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPointPosScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			switch (PlayerPrefs.GetInt("Selected slot")) {
				case 1:
					PlayerPrefs.SetFloat("Slot1X", transform.position.x);
					PlayerPrefs.SetFloat("Slot1Y", transform.position.y);
					PlayerPrefs.SetFloat("Slot1Z", transform.position.z);
					break;
				case 2:
					PlayerPrefs.SetFloat("Slot2X", transform.position.x);
					PlayerPrefs.SetFloat("Slot2Y", transform.position.y);
					PlayerPrefs.SetFloat("Slot2Z", transform.position.z);
					break;
				case 3:
					PlayerPrefs.SetFloat("Slot3X", transform.position.x);
					PlayerPrefs.SetFloat("Slot3Y", transform.position.y);
					PlayerPrefs.SetFloat("Slot3Z", transform.position.z);
					break;
				default:
					break;
			}
		}
	}
}
