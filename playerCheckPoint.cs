using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCheckPoint : MonoBehaviour {

	private float startX;
	private float startY;
	private float startZ;
	
	void Start () {
		
		startX = 10.7f;
		startY = 0.81f;
		startZ = -27.25f;
		
		switch (PlayerPrefs.GetInt("Selected slot")) {
			case 1:
				if (PlayerPrefs.HasKey("Slot1X")) {
					startX = PlayerPrefs.GetFloat("Slot1X");
					startY = PlayerPrefs.GetFloat("Slot1Y");
					startZ = PlayerPrefs.GetFloat("Slot1Z");
				}
				break;
			case 2:
				if (PlayerPrefs.HasKey("Slot2X")) {
					startX = PlayerPrefs.GetFloat("Slot2X");
					startY = PlayerPrefs.GetFloat("Slot2Y");
					startZ = PlayerPrefs.GetFloat("Slot2Z");
				}
				break;
			case 3:
				if (PlayerPrefs.HasKey("Slot3X")) {
					startX = PlayerPrefs.GetFloat("Slot3X");
					startY = PlayerPrefs.GetFloat("Slot3Y");
					startZ = PlayerPrefs.GetFloat("Slot3Z");
				}
				break;
			default:
				break;
		}
		
		transform.position = new Vector3(startX, startY, startZ);
		
	}
}
