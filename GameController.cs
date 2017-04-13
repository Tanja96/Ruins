using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : MonoBehaviour {

    public static GameController Instance { set; get; }

    private PlayerPosOnLoad playerPos;
    //private MainMenuV2Script menu;

    public Transform canvas;
    public string curLevel;
    public float posX, posY, posZ;
    public bool startedGame = false;

    // Use this for initialization
    void Awake () {

        Instance = this;
        loadScene("Player");
        loadScene("Taso0");
        //menu.SaveStartedGame();

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

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.curLevel = curLevel;
        data.posX = posX;
        data.posY = posY;
        data.posZ = posZ;

        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            curLevel = data.curLevel;
            posX = data.posX;
            posY = data.posY;
            posZ = data.posZ;

            SceneManager.LoadScene(1);
            unloadScene("Player");
            unloadScene("Taso0");
            
            loadScene(curLevel);
            loadScene("Player");
            playerPos.PosOnLoad(posX, posY, posZ);
        }
    }

    public void loadScene(string sceneName)
    {
        if (!SceneManager.GetSceneByName(sceneName).isLoaded)
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }
    public void unloadScene(string sceneName)
    {
        if (SceneManager.GetSceneByName(sceneName).isLoaded)
            SceneManager.UnloadSceneAsync(sceneName);
    }

    //public void SaveStartedGame()
    //{
    //    BinaryFormatter bf = new BinaryFormatter();
    //    FileStream file2 = File.Create(Application.persistentDataPath + "/playerStartInfo.dat");

    //    PlayerData data = new PlayerData();
    //    data.startedGame = startedGame;

    //    bf.Serialize(file2, data);
    //    file2.Close();
    //}

    //public void LoadStartedGame()
    //{
    //    if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
    //    {
    //        BinaryFormatter bf = new BinaryFormatter();
    //        FileStream file2 = File.Open(Application.persistentDataPath + "/playerStartInfo.dat", FileMode.Open);
    //        PlayerData data = (PlayerData)bf.Deserialize(file2);

    //        startedGame = data.startedGame;

    //        file2.Close();
    //    }
    //}
}

[Serializable]
class PlayerData
{
    //public bool startedGame;
    public string curLevel;
    public float posX, posY, posZ;
}
