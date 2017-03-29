using UnityEngine;
using System.Collections;

public class DungeonCamera : MonoBehaviour {

    public GameObject player;
	public float rotateSpeed = 5f;
	
    private Vector3 offset;
 
    void Start() {
        offset = player.transform.position - transform.position;
    }
	
	void LateUpdate() {
		
		float desiredAngle = player.transform.eulerAngles.y;
		Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
		transform.position = player.transform.position - (rotation * offset);
			
		if (Input.GetKey("mouse 1")) {
			float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
			float vertical = -Input.GetAxis("Mouse Y") * rotateSpeed;
			
			transform.RotateAround(player.transform.position, Vector3.up, horizontal);
			transform.RotateAround(player.transform.position, transform.right, vertical);
		} else {
			transform.LookAt(player.transform);
		}
	}
}
