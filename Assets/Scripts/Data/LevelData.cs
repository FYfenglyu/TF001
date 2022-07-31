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
        LevelConfigEle config;
        string jsonFileContent = TextResourceReader.Read(jsonFilePath);
        config = JsonMapper.ToObject<LevelConfigEle>(jsonFileContent);

        return config;
    }

    public static LevelConfig GetLevelConfig(int levelIndex)
    {
        LevelConfig levelconfig = new();

        //load hunters generate config
        List<HunterGenInfo> hunterGenInfoList = LoadHunterGenInfoList(GetLevelHuntersConfigPath(levelIndex));
        //load card config
        LevelConfigEle config = LoadLevelConfig(GetLevelConfigPath(levelIndex));

        levelconfig.initCost = config.initCost;
        levelconfig.cardIDList = config.cardIDList;
        levelconfig.hunterGenInfoList = hunterGenInfoList;
        levelconfig.hunterNum = hunterGenInfoList.Count;

        return levelconfig;
    }
}