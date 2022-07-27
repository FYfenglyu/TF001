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

    private List<HunterGenInfo> hunterGenInfoList = new List<HunterGenInfo>();    // hunter spawn information list (spawn time, hunter ID)
    private int currHunterIndex = 0;    // hunter index which is the next one to be spawned
    private int maxHunterIndex;     // total hunter number
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        hunter01 = Resources.Load<Hunter>("Hunters/hunter_01");
        hunter02 = Resources.Load<Hunter>("Hunters/hunter_02");
        hunter03 = Resources.Load<Hunter>("Hunters/hunter_03");

        hunterContainer = GameObject.Find("Hunters");

        LoadHunterGenInfoList();
    }

    private void FixedUpdate()
    {
        foreach (Hunter m in hunters)
        {
            MoveHunter(m, true);
        }
    }

    // Update is called once per frame
    private void Update() {
        GenerateHunterOnConfig();
    }

    public bool GenerateHunter(int hid, Vector3 birthPosition)
    {
        Hunter prototype = GetHunter(hid);
        if (prototype)
        {
            Hunter newHunter = GameObject.Instantiate(prototype, birthPosition, Quaternion.identity);
            newHunter.transform.SetParent(hunterContainer.transform, false);

            hunters.Add(newHunter);
            
            return true;
        }
        return false;
    }

    public Hunter GetHunter(int hid)
    {
        Hunter aM = hunter01;
        if (hid == 0)
            aM = hunter01;
        else if (hid == 1)
            aM = hunter02;
        else if (hid == 2)
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

    private void LoadHunterGenInfoList()
    {
        // load hunter spawn information list from json file
        string jsonFilePath = Application.streamingAssetsPath + "/../../Config/HunterSpawn_L1.json";
        hunterGenInfoList = JsonMapper.ToObject<List<HunterGenInfo>>(File.ReadAllText(jsonFilePath));

        // sort hunter generation information by spawn time 
        hunterGenInfoList.Sort();

        // set total hunter number
        maxHunterIndex = hunterGenInfoList.Count;
    }

    private void GenerateHunterOnConfig()
    {
        for (; currHunterIndex < maxHunterIndex; ++currHunterIndex)
        {
            if (TimeManager.instance.GetTimeSecond() >= hunterGenInfoList[currHunterIndex].birthTime)
            {
                if(!GenerateHunter(hunterGenInfoList[currHunterIndex].hunterID, GameManager.instance.originalPos))
                {
                    Debug.Log("Fali to generate hunter.");
                }
            }
            else
            {
                break;
            }
        }
    }
}
