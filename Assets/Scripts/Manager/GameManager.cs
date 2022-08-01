using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
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
        jsonFilePath = Application.persistentDataPath + jsonFilePath;

        // if there exists no local unlocked level number json file, create one
        if (!File.Exists(jsonFilePath)) return defaultLevelNum;

        string jsonFileContent = File.ReadAllText(jsonFilePath);
        if (jsonFileContent == null) return defaultLevelNum;

        int unlockedLevelNumInConfig = JsonMapper.ToObject<int>(jsonFileContent);
        Debug.Log("Content:");
        Debug.Log(jsonFileContent);
        return unlockedLevelNumInConfig;
    }

    private void SaveUnlockedLevelNumToJson(string jsonFilePath)
    {
        // jsonFilePath = Application.persistentDataPath + "/" + jsonFilePath;
        // string jsonFileContent = JsonMapper.ToJson<int>(unlockedLevelNum);

        // using (FileStream jsonFile = new FileStream(jsonFilePath, FileMode.Create))
        // {
        //     using (StreamWriter streamWriter = new StreamWriter(jsonFile))
        //     {
        //         streamWriter.WriteLine(jsonFileContent);
        //     }
        // }
    }

    public int LevelUp()
    {
        unlockedLevelNum = Mathf.Min(totalLevelNum, unlockedLevelNum + 1);
        return unlockedLevelNum;
    }
    public void ReplayLevel() { LoadLevel(lastLevel); }
    public void ReloadLevel() { LoadLevel(unlockedLevelNum); }
    public void LoadLevel(int level)
    {
        levelConfig = LevelData.GetLevelConfig(level);

        LoadScene("SampleScene");

        lastLevel = level;
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
}