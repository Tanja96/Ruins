using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {
	
	public Transform[] checkpoints;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Death") {
			Transform spawnPoint = GetClosestCP(checkpoints);
			transform.position = spawnPoint.position;
		}
	}
	
	Transform GetClosestCP(Transform[] checkpoints) {
		Transform tMin = null;
		float minDist = Mathf.Infinity;
		Vector3 currentPos = transform.position;
		foreach (Transform t in checkpoints) {
			float dist = Vector3.Distance(t.position, currentPos);
			if (dist < minDist)
			{
				tMin = t;
				minDist = dist;
			}
		}
		return tMin;
	}
	
}
