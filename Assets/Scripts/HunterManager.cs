using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterManager : MonoBehaviour
{
    public static HunterManager instance;
    public List<Hunter> hunters;
    protected Hunter hunter01;
    protected Hunter hunter02;
    protected Hunter hunter03;

    private void Awake() {
        instance = this;
    }

    void Start()
    {
        hunter01 = Resources.Load<Hunter>("Hunters/hunter_01");
        hunter02 = Resources.Load<Hunter>("Hunters/hunter_02");
        hunter03 = Resources.Load<Hunter>("Hunters/hunter_03");
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Hunter m in hunters)
        {
            if(m.moving)
                MoveHunter(m, true);
        }
    }


    public bool GenerateHunter(int hid, Vector3 birthPosition)
    {
        Hunter prototype = GetHunter(hid);
        if(prototype)
        {
            Hunter newHunter = GameObject.Instantiate(prototype, birthPosition, Quaternion.identity);
            hunters.Add(newHunter);
            return true;
        }
        return false;
    }

    public Hunter GetHunter(int hid)
    {
        Hunter aM = hunter01;
        if(hid == 0)
            aM = hunter01;
        else if(hid == 1)
            aM = hunter02;
        else if(hid == 2)
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
}
