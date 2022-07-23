using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager instance;
    public List<Monster> monsters;
    public Monster monsterExample;

    private void Awake() {
        instance = this;
    }

    void Start()
    {

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


    public Monster GenerateMonster(int mid, Vector3 birthPosition)
    {
        Monster newMonster = GameObject.Instantiate(GetMonster(mid), birthPosition, Quaternion.identity);
        monsters.Add(newMonster);
        return newMonster;
    }

    public Monster GetMonster(int mid)
    {
        // 建立怪物库后进行获取 TODO
        return monsterExample;
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
