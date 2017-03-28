using UnityEngine;
using System.Collections;

public class PlayerFeatherScript : MonoBehaviour {

	public int featherCount;

	// Use this for initialization
	void Start () {
		
		featherCount = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Feather") {
			featherCount++;
			Destroy(col.gameObject);
		}
	}
	
}
