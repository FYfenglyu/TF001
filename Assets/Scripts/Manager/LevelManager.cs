using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;
using LitJson;

using static ConstantTable;


public class HunterGenInfo : IComparable<HunterGenInfo>
{
    public double birthTime;
    public int hunterID;

    // make it comparable
    public int CompareTo(HunterGenInfo anoGenInfo)
    {
        return birthTime.CompareTo(anoGenInfo.birthTime);
    }

}

public struct LevelConfig
{
    public int initCost;
    public List<int> cardIDList;

}

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private List<HunterGenInfo> hunterGenInfoList = new List<HunterGenInfo>();    // hunter spawn information list (spawn time, hunter ID)
    private ProgressBar hunterProgress;
    private int currHunterIndex = 0;    // hunter index which is the next one to be spawned
    private int maxHunterIndex = 1;     // total hunter number
    private bool isGenerateFinished = false;

    private LevelConfig config;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        hunterProgress = GameObject.Find("HunterProgress").GetComponent<ProgressBar>();
        LoadHunterGenInfoList();
    }

    // Update is called once per frame
    private void Update()
    {
        GenerateHunterOnConfig();
        hunterProgress.SetCurrHP(maxHunterIndex - currHunterIndex + HunterManager.instance.hunters.Count);
    }

    public void LoadHunterGenInfoList(string path)
    {
        // load hunter spawn information list from json file
        string jsonFilePath = Application.streamingAssetsPath + path;
        hunterGenInfoList = JsonMapper.ToObject<List<HunterGenInfo>>(File.ReadAllText(jsonFilePath));

        // sort hunter generation information by spawn time 
        hunterGenInfoList.Sort();

        // foreach (HunterGenInfo info_i in hunterGenInfoList)
        // {
        //     Debug.Log(new String("Spawn Hunter: ") + info_i.birthTime.ToString() + new String(" : ") + info_i.hunterID.ToString());
        // }

        // change UI
        maxHunterIndex = hunterGenInfoList.Count;
        hunterProgress.SetTotalHP(maxHunterIndex);

        isGenerateFinished = false;
    }
    public void LoadHunterGenInfoList()
    {
#if UNITY_EDITOR
        string genInfoPath = new String("/../../") + new String(PATH_LEVELCONFIG_TEST);
#else
        string genInfoPath = new String(PATH_LEVELCONFIG_TEST);
#endif
        LoadHunterGenInfoList(genInfoPath);
    }

    public void LoadLevelConfig(string path)
    {
        string jsonFilePath = Application.streamingAssetsPath + path;
        config = JsonMapper.ToObject<LevelConfig>(File.ReadAllText(jsonFilePath));

        Debug.Log("新生成卡牌id" + config.cardIDList.ToString());

        ProjectileManager.instance.SetCardsList(config.cardIDList);
    }

    public void GenerateHunterOnConfig()
    {
        for (; currHunterIndex < maxHunterIndex; ++currHunterIndex)
        {
            if (TimeManager.instance.GetCurrTime() >= hunterGenInfoList[currHunterIndex].birthTime)
            {
                if (!HunterManager.instance.GenerateHunter(hunterGenInfoList[currHunterIndex].hunterID, GameManager.instance.originalPos))
                {
                    Debug.Log("Fali to generate hunter. Hunter ID : " + hunterGenInfoList[currHunterIndex].hunterID.ToString());
                }
            }
            else
            {
                break;
            }
        }
    }

    public void LoadLevel(int levelIndex)
    {
        //load hunters generate config
        LoadHunterGenInfoList( GetLevelHuntersConfigPath(levelIndex));
        //load card config
        LoadLevelConfig( GetLevelConfigPath(levelIndex));
        //get level prefab

        //set level prefab

        ///reset scores, cost and timemanager
        currHunterIndex = 0;
        GameManager.instance.ResetGameStatus();
    }

    public bool IsGenerateFinished()
    {
        if (currHunterIndex == maxHunterIndex)
            isGenerateFinished = true;
        return isGenerateFinished;
    }
}