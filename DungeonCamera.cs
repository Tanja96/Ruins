using UnityEngine;
using System.Collections;

public class DungeonCamera : MonoBehaviour {

    private Vector3 offset;
    private Vector3 def_offset;
    private Vector3 zoom_offset;

    public GameObject player;
	public float rotateSpeed = 5f;

    void Start() {
        offset = player.transform.position - transform.position;
        def_offset = offset;
        zoom_offset = offset - new Vector3(0, offset.y + 0.6f, offset.z);
    }
	
	void LateUpdate() {
        
        float desiredAngle = player.transform.eulerAngles.y;
		Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = player.transform.position - (rotation * offset);
        
		if (Input.GetKey("mouse 1")) {
            
            offset = zoom_offset; 
            
			float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
			float vertical = -Input.GetAxis("Mouse Y") * rotateSpeed;
			
			transform.RotateAround(player.transform.position, Vector3.up, horizontal);
			transform.RotateAround(player.transform.position, transform.right, vertical);
		} else {
			transform.LookAt(player.transform);
            offset = def_offset;
		}
        
	}
}
