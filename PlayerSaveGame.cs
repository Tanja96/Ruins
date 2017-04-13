using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerSaveGame : MonoBehaviour {

    public GameObject spawnPos;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameController.Instance.curLevel = gameObject.scene.name; //SceneManager.GetActiveScene().buildIndex;
            GameController.Instance.posX = spawnPos.transform.position.x;
            GameController.Instance.posY = spawnPos.transform.position.y;
            GameController.Instance.posZ = spawnPos.transform.position.z;

            GameController.Instance.SaveGame();
            Debug.Log("Checkpoint");
        }
    }
}
