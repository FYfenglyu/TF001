using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;
using LitJson;

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

public class HunterManager : MonoBehaviour
{
    public static HunterManager instance;
    public List<Hunter> hunters;
    protected Hunter hunter01;
    protected Hunter hunter02;
    protected Hunter hunter03;

    private GameObject hunterContainer;     // UI : hunter list
    private ProgressBar gameProgress;

    private List<HunterGenInfo> hunterGenInfoList = new List<HunterGenInfo>();    // hunter spawn information list (spawn time, hunter ID)
    private int currHunterIndex = 0;    // hunter index which is the next one to be spawned
    private int maxHunterIndex;     // total hunter number

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        hunter01 = Resources.Load<Hunter>("Prefabs/Hunters/hunter_01");
        hunter02 = Resources.Load<Hunter>("Prefabs/Hunters/hunter_02");
        hunter03 = Resources.Load<Hunter>("Prefabs/Hunters/hunter_03");

        hunterContainer = GameObject.Find("Hunters");
        gameProgress = GameObject.Find("GameProgress").GetComponent<ProgressBar>();


        LoadHunterGenInfoList();

        gameProgress.SetTotalHP(maxHunterIndex);
    }

    private void FixedUpdate()
    {
        foreach (Hunter m in hunters)
        {
            MoveHunter(m, true);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        GenerateHunterOnConfig();
        gameProgress.SetCurrHP(maxHunterIndex - currHunterIndex);
    }

    public bool GenerateHunter(int hid, Vector3 birthPosition)
    {
        Hunter prototype = GetHunter(hid);
        if (prototype)
        {
            Hunter newHunter = GameObject.Instantiate(prototype, birthPosition, Quaternion.identity);
            newHunter.transform.SetParent(hunterContainer.transform, false);

            hunters.Add(newHunter);
            Debug.Log(new String("Hunter count : ") + hunters.Count.ToString());

            return true;
        }
        return false;
    }

    public Hunter GetHunter(int hid)
    {
        Hunter aM = hunter01;
        if (hid == 301)
            aM = hunter01;
        else if (hid == 302)
            aM = hunter02;
        else if (hid == 303)
            aM = hunter03;
        // 建立怪物库后进行获取 TODO
        return aM;
    }

    public void MoveHunter(Hunter m, bool goLeft)
    {
        m.Move(goLeft);
    }
    public void DestoryHunter(Hunter m)
    {
        m.Dead();
    }

    public void ClearHunter(Hunter hunter)
    {
    }

    //  建议拉到LevelManager上
    private void LoadHunterGenInfoList()
    {
        // load hunter spawn information list from json file
        string jsonFilePath = Application.streamingAssetsPath + "/../../Config/HunterSpawn_L1.json";
        hunterGenInfoList = JsonMapper.ToObject<List<HunterGenInfo>>(File.ReadAllText(jsonFilePath));

        // sort hunter generation information by spawn time 
        hunterGenInfoList.Sort();
        // foreach (HunterGenInfo info_i in hunterGenInfoList)
        // {
        //     Debug.Log(new String("Spawn Hunter: ") + info_i.birthTime.ToString() + new String(" : ") + info_i.hunterID.ToString());
        // }

        // set total hunter number
        maxHunterIndex = hunterGenInfoList.Count;
    }

    private void GenerateHunterOnConfig()
    {
        for (; currHunterIndex < maxHunterIndex; ++currHunterIndex)
        {
            if (TimeManager.instance.GetCurrTime() >= hunterGenInfoList[currHunterIndex].birthTime)
            {
                if (!GenerateHunter(hunterGenInfoList[currHunterIndex].hunterID, GameManager.instance.originalPos))
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

    public bool areHuntersAllDead()
    {
        return currHunterIndex == maxHunterIndex && hunters.Count == 0;
    }
}
