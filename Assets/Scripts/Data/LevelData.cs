using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
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

public struct LevelConfigEle
{
    public int initCost;
    public List<int> cardIDList;
}

public struct LevelConfig
{
    public int initCost;
    public List<int> cardIDList;
    public List<HunterGenInfo> hunterGenInfoList;
    public int hunterNum;
}

public class LevelData
{
    // 这两个load函数可以考虑合并为一个！，遗留问题
    public static List<HunterGenInfo> LoadHunterGenInfoList(string jsonFilePath)
    {
        // load hunter spawn information list from json file
        // hunter spawn information list (spawn time, hunter ID)
        List<HunterGenInfo> hunterGenInfoList = new List<HunterGenInfo>();
        string jsonFileContent = TextResourceReader.Read(jsonFilePath);
        hunterGenInfoList = JsonMapper.ToObject<List<HunterGenInfo>>(jsonFileContent);

        // sort hunter generation information by spawn time 
        hunterGenInfoList.Sort();
        foreach (HunterGenInfo info_i in hunterGenInfoList)
        {
            Debug.Log(new String("Spawn Hunter: ") + info_i.birthTime.ToString() + new String(" : ") + info_i.hunterID.ToString());
        }
        return hunterGenInfoList;
    }

    public static LevelConfigEle LoadLevelConfig(string jsonFilePath)
    {
        string jsonFileContent = TextResourceReader.Read(jsonFilePath);
        LevelConfigEle config = JsonMapper.ToObject<LevelConfigEle>(jsonFileContent);

        return config;
    }

    public static LevelConfig GetLevelConfig(int levelIndex)
    {
        LevelConfig levelConfig = new LevelConfig();

        //load hunters generate config
        List<HunterGenInfo> hunterGenInfoList = LoadHunterGenInfoList(GetLevelHuntersConfigPath(levelIndex));
        //load card config
        LevelConfigEle config = LoadLevelConfig(GetLevelConfigPath(levelIndex));

        levelConfig.initCost = config.initCost;
        levelConfig.cardIDList = config.cardIDList;
        levelConfig.hunterGenInfoList = hunterGenInfoList;
        levelConfig.hunterNum = hunterGenInfoList.Count;

        return levelConfig;
    }
}