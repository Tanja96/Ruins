using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwinging : MonoBehaviour {

    private CharacterController controller;

    void Start() {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame

    void OnTriggerEnter(Collider col) {
        if (Input.GetMouseButtonDown(1) && col.CompareTag("Liana")) {
            transform.SetParent(col.gameObject.transform);
        }
    }
    void OnTriggerStay(Collider col) {
        if (Input.GetMouseButtonDown(1) && col.CompareTag("Liana")) {
            transform.SetParent(col.gameObject.transform);
        }
    }
    void OnTriggerExit(Collider col) {
        if (!Input.GetMouseButtonDown(1) && col.CompareTag("Liana")) {
            transform.SetParent(null);
        }
    }
}
