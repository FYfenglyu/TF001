using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ConstantTable;

public class HunterManager : MonoBehaviour
{
    public static HunterManager instance;
    public List<Hunter> hunters;
    private GameObject hunterContainer;     // UI : hunter list

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        hunterContainer = GameObject.Find("Hunters");
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
        switch(hid)
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
        while(hunters.Count > 0)
        {
            hunters[0].Dead();
        }
    }

    public bool AreHuntersAllDead()
    {
        if(LevelManager.instance==null) Debug.Log("what is wrong.");
        return LevelManager.instance.IsGenerateFinished() && hunters.Count == 0;
    }
}
