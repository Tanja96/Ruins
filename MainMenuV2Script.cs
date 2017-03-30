using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuV2Script : MonoBehaviour
{

    public void startNewGame(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void exitToDesktop()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
};