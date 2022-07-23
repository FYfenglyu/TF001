using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager instance;
    public List<Monster> monsters;
    protected Monster monster01;
    protected Monster monster02;
    protected Monster monster03;

    private void Awake() {
        instance = this;
    }

    void Start()
    {
        monster01 = Resources.Load<Monster>("prefabs/hunter01");
        monster02 = Resources.Load<Monster>("prefabs/hunter02");
        monster03 = Resources.Load<Monster>("prefabs/hunter03");
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Monster m in monsters)
        {
            if(m.moving)
                MoveMonster(m, true);
        }
    }


    public bool GenerateMonster(int mid, Vector3 birthPosition)
    {
        Monster prototype = GetMonster(mid);
        if(prototype)
        {
            Monster newMonster = GameObject.Instantiate(prototype, birthPosition, Quaternion.identity);
            monsters.Add(newMonster);
            return true;
        }
        return false;
    }

    public Monster GetMonster(int mid)
    {
        Monster aM = monster01;
        if(mid == 0)
            aM = monster01;
        else if(mid == 1)
            aM = monster02;
        else if(mid == 2)
            aM = monster03;
        // 建立怪物库后进行获取 TODO
        return aM;
    }    
    
    public void MoveMonster(Monster m, bool goLeft)
    {
        m.Move(goLeft);
    }
    public void DestoryMonster(Monster m)
    {
        m.Dead();
    }

    public void ClearMonster(Monster monster)
    {
    }
}
