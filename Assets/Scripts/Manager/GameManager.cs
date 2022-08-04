using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using LitJson;
using static ConstantTable;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // singleton

    [Header("默认开启的关卡数量")]
    public int defaultLevelNum = 3;

    private int unlockedLevelNum = 1;
    private int lastLevel = 1;
    private int totalLevelNum = 16;

    private float bounceFrequency = 2.8f;
    private float maxDis = 1.05f;
    private float minDis = 0.3f;

    private LevelConfig levelConfig;

    // Start is called before the first frame update
    private void Awake()
    {
        // if there exists an instance, destroy the unnecessary instance 
        if (instance)
        {
            if (instance != this) GameObject.Destroy(gameObject);
            return;
        }

        // create an instance
        instance = this;
        GameObject.DontDestroyOnLoad(gameObject);

        // load local unlocked level number form Application.persistentDataPath
        unlockedLevelNum = LoadUnlockedLevelNumFromJson(LOCAL_UNLOCKEDLEVELNUM_PATH);
        unlockedLevelNum = unlockedLevelNum > defaultLevelNum ? unlockedLevelNum : defaultLevelNum;
    }

    private void OnDestroy()
    {
        // save local unlocked level number to Application.persistentDataPath
        SaveUnlockedLevelNumToJson(LOCAL_UNLOCKEDLEVELNUM_PATH);
    }

    private int LoadUnlockedLevelNumFromJson(string jsonFilePath)
    {
        // reunion json file path
        jsonFilePath = Application.persistentDataPath + "/" + jsonFilePath;

        // if there exists no local unlocked level number json file, create one
        if (!File.Exists(jsonFilePath)) return defaultLevelNum;

        string jsonFileContent = File.ReadAllText(jsonFilePath);
        if (jsonFileContent == null) return defaultLevelNum;

        int unlockedLevelNumInConfig = Convert.ToInt32(jsonFileContent);
        return unlockedLevelNumInConfig;
    }

    private void SaveUnlockedLevelNumToJson(string jsonFilePath)
    {
        // jsonFilePath = Application.persistentDataPath + "/" + jsonFilePath;

        // UnityWebRequest request = UnityWebRequest.Get(jsonFilePath);
        // request.SendWebRequest();

        // while(!request.isDone())
        // {
        //     request.downloadProgress();
        // }
        
        // string str = request.downloadHandler.text;
    }

    public int LevelUp()
    {
        unlockedLevelNum = Mathf.Min(totalLevelNum, unlockedLevelNum + 1);
        return unlockedLevelNum;
    }
    public void ReplayLevel() { LoadLevel(lastLevel); }
    public void ReloadLevel() { LoadLevel(lastLevel + 1); }
    public void LoadLevel(int level)
    {
        levelConfig = LevelData.GetLevelConfig(level);

        LoadDiffScene(level);

        lastLevel = level;
    }

    public void LoadDiffScene(int i)
    {
        if(i > 0 && i < NUM_SWITCH_SCENE2)
        {
            bounceFrequency = NUM_BOUNCE_1;
            maxDis = 1.05f;
            minDis = 0.3f;
            LoadScene("SampleScene");
        }
        else if(i >= NUM_SWITCH_SCENE2 && i < NUM_SWITCH_SCENE3)
        {
            bounceFrequency = NUM_BOUNCE_2;
            maxDis = 1.2f;
            minDis = 0.3f;
            LoadScene("Scene2");
        }
        else if(i >= NUM_SWITCH_SCENE3 && i <= NUM_MAXLEVEL)
        {
            bounceFrequency = NUM_BOUNCE_3;
            maxDis = 1.6f;
            minDis = 0.3f;
            LoadScene("Scene3");
        } 
    }

    public int GetUnlockedLevelNum() { return unlockedLevelNum; }

    public bool canLevelUp()
    {
        return unlockedLevelNum == lastLevel;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public LevelConfig GetLevelConfig() { return levelConfig; }

    public float GetBounce()
    {
        return bounceFrequency;
    }

    public float GetMinDis()
    {
        return minDis;
    }

    public float GetMaxDis()
    {
        return maxDis;
    }
}