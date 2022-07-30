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

    private void FixedUpdate()
    {
        foreach (Hunter m in hunters)
        {
            MoveHunter(m, true);
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

    public bool AreHuntersAllDead()
    {
        if(LevelManager.instance==null) Debug.Log("what is wrong.");
        return LevelManager.instance.IsGenerateFinished() && hunters.Count == 0;
    }
}
