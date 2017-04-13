using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MainMenuV2Script : MonoBehaviour
{
    Text text;

    //public bool startedGame = false;

    //void Start()
    //{
    //    //LoadStartedGame();
    //    if (startedGame) //GameController.Instance.startedGame
    //    {
    //        text.GetComponent<Text>();
    //        text.text = "Continue Game";
    //    }
        
    //}
    public void startNewGame(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ContinueGame(int sceneIndex)
    {
        GameController.Instance.LoadGame();
    }

    public void exitToDesktop()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

//    public void SaveStartedGame()
//    {
//        BinaryFormatter bf = new BinaryFormatter();
//        FileStream file2 = File.Create(Application.persistentDataPath + "/playerStartInfo.dat");

//        StartData data = new StartData();
//        data.startedGame = startedGame;

//        bf.Serialize(file2, data);
//        file2.Close();
//    }

//    public void LoadStartedGame()
//    {
//        if (File.Exists(Application.persistentDataPath + "/playerStartInfo.dat"))
//        {
//            BinaryFormatter bf = new BinaryFormatter();
//            FileStream file2 = File.Open(Application.persistentDataPath + "/playerStartInfo.dat", FileMode.Open);
//            StartData data = (StartData)bf.Deserialize(file2);
//            file2.Close();

//            startedGame = data.startedGame;
//        }
//    }
}

//[Serializable]
//class StartData
//{
//    public bool startedGame;
//}