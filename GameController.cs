﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Transform canvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
            }else
            {
                canvas.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }

	}

    public void continueGame()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void exitToMain(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
