using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ConstantTable;

public class HunterManager : MonoBehaviour
{
    public static HunterManager instance;
    private List<HunterGenInfo> hunterGenInfoList;
    public List<Hunter> hunters;
    private GameObject hunterContainer;     // UI : hunter list

    [Header("怪物数量相关")]
    private int totalHunterNum = 10;
    private int deadHunterNum = 0;
    private int genHunterNum = 0;
    private bool isGenerateFinished = false;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        hunterContainer = GameObject.Find("Hunters");
    }

    public void ResetParam(LevelConfig config)
    {
        totalHunterNum = config.hunterNum;
        hunterGenInfoList = config.hunterGenInfoList;
        Debug.Log(hunterGenInfoList);
        deadHunterNum = 0;
        genHunterNum = 0;
        isGenerateFinished = false;
    }
    public int GetCurrHunterNum()
    {
        return genHunterNum - deadHunterNum;
    }
    public int GetLeaveHunterNum()
    {
        return totalHunterNum - deadHunterNum;
    }
    public int GetTotalHunterNum()
    {
        return totalHunterNum;
    }
    public void GenerateHunter(LevelConfig config)
    {
        for (; genHunterNum < totalHunterNum; ++genHunterNum)
        {
            if (TimeManager.instance.GetCurrTime() < hunterGenInfoList[genHunterNum].birthTime) break;

            if (!GenerateHunter(hunterGenInfoList[genHunterNum].hunterID, PlayManager.instance.originalPos))
            {
                Debug.Log("Fali to generate hunter. Hunter ID : " + hunterGenInfoList[genHunterNum].hunterID.ToString());
            }
        }
    }

    public Hunter GenerateHunter(int hid, Vector3 birthPosition)
    {
        Hunter prototype = GetHunter(hid);
        if (prototype)
        {
            Hunter newHunter = GameObject.Instantiate(prototype, birthPosition, Quaternion.identity);
            newHunter.transform.SetParent(hunterContainer.transform, false);

            hunters.Add(newHunter);
            Debug.Log("Hunter count : " + hunters.Count.ToString());
            return newHunter;
        }
        return prototype;
    }

    public bool TryGenerateHunter(int hid, Vector3 birthPosition)
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
        Hunter aH = null;
        switch (hid)
        {
            case 301:
                aH = Resources.Load<Hunter>(PREFAB_HUNTER_01);
                break;
            case 302:
                aH = Resources.Load<Hunter>(PREFAB_HUNTER_02);
                break;
            case 303:
                aH = Resources.Load<Hunter>(PREFAB_HUNTER_03);
                break;
        }
        return aH;
    }

    public void MoveHunter(Hunter h, Vector3 displacement)
    {
        h.Move(displacement);
    }
    public void DestoryHunter(Hunter h)
    {
        h.Dead();
    }
    public void ClearHunters()
    {
        while (hunters.Count > 0)
        {
            hunters[0].Dead();
        }
    }

    public bool AreHuntersAllDead()
    {
        return IsGenerateFinished() && hunters.Count == 0;
    }

    public bool IsGenerateFinished()
    {
        if (genHunterNum == totalHunterNum)
            isGenerateFinished = true;
        return isGenerateFinished;
    }
}
