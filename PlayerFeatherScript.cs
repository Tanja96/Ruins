using UnityEngine;
using System.Collections;

public class PlayerFeatherScript : MonoBehaviour {

	public int featherCount;

	void Start() {
		featherCount = 0;
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Feather") {
			featherCount++;
			Destroy(other.gameObject);
		}
	}
}
