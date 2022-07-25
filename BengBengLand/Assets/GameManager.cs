using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    public const string TAG_BIRTHDOOR = "Respawn";
    public const string TAG_DEADDOOR = "Finish";

    public GameObject birthDoor;
    public GameObject deadDoor;

    // Start is called before the first frame update
    public Vector3 originalPos;
    public Vector3 targetPos;

    private int playerScore =  3;

    private void Awake() {
        instance = this;

        birthDoor = GameObject.FindWithTag(TAG_BIRTHDOOR);
        deadDoor = GameObject.FindWithTag(TAG_DEADDOOR);

        originalPos = birthDoor.transform.position;
        targetPos = deadDoor.transform.position;

        InitPlayer();
    }
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TestGenerateMonster();
    }

    public void TestGenerateMonster()
    {
        if(Time.frameCount % 8000 == 1)
            MonsterManager.instance.GenerateMonster(0, originalPos);
        if(Time.frameCount % 8000 == 4000)
            MonsterManager.instance.GenerateMonster(1, originalPos);
        if(Time.frameCount % 8000 == 2000)
            MonsterManager.instance.GenerateMonster(2, originalPos);
    
    }

    public void InitPlayer()
    {
        playerScore = 3;
    }
    public void LoseScore()
    {
        if(playerScore > 0)
            playerScore -= 1;
        else
        {
            print("游戏结束");
        }
    }

    public void CutCost(GameObject go)
    {
        //获取go的费用
        //减费
    }

}
