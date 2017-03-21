﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCamera : MonoBehaviour {

    public GameObject target;
    public float rotateSpeed = 9.0f;
    public float damping = 0.2f;
    Vector3 offset;
     
    void Start() {
        offset = target.transform.position - transform.position;
    }
     
    void LateUpdate() {

        if (Input.GetAxis("Vertical") == 0) {
            float horizontal = Input.GetAxis("Horizontal") * rotateSpeed;
            transform.Rotate(0, horizontal, 0);
        } else {
            float currentAngle = transform.eulerAngles.y;
float desiredAngle = target.transform.eulerAngles.y;
float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);
Quaternion rotation = Quaternion.Euler(0, angle, 0);
            transform.position = target.transform.position - (rotation * offset);
            transform.LookAt(target.transform, Vector3.up);
        }
    }
}
