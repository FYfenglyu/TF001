using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager instance;
    public List<Monster> monsters;
    public Monster monsterExample;
    protected GameObject birthDoor;
    protected GameObject deadDoor;

    // Start is called before the first frame update
    Vector3 originalPosition;
    Vector3 targetPosition;

    public const string TAG_BIRTHDOOR = "Respawn";
    public const string TAG_DEADDOOR = "Finish";
    private void Awake() {
        instance = this;
    }

    void Start()
    {
        birthDoor = GameObject.FindWithTag(TAG_BIRTHDOOR);
        deadDoor = GameObject.FindWithTag(TAG_DEADDOOR);

        originalPosition = birthDoor.transform.position;
        targetPosition = deadDoor.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.frameCount % 40 == 1)
            monsters.Add(GenerateMonster(0,originalPosition));
        foreach(Monster m in monsters)
        {
            m.Move(true, targetPosition);
        }
    }


    public Monster GenerateMonster(int mid, Vector3 position)
    {
        Monster newMonster = GameObject.Instantiate(GetMonster(mid), position, Quaternion.identity);
        return newMonster;
    }
    public Monster GetMonster(int mid)
    {
        return monsterExample;
    }    
    
    public void DestoryMonster(Monster monster)
    {
        monster.Dead();
    }

    public void clearMonster(Monster monster)
    {
    }
}
