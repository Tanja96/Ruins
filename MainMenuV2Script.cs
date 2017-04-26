using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuV2Script : MonoBehaviour
{
	
    public void startNewGame(int slotNumber) {
		PlayerPrefs.SetInt("Selected slot", slotNumber);
		SceneManager.LoadScene("Player");
		SceneManager.LoadScene("Taso0", LoadSceneMode.Additive);
		SceneManager.LoadScene("Taso1", LoadSceneMode.Additive);
		SceneManager.LoadScene("Taso2", LoadSceneMode.Additive);
    }

    public void exitToDesktop() {
        Application.Quit();
    }
};