using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // singleton

    [Header("全局总费用")]
    public int totalCost = 1000;

    [Header("每秒回复的费用")]

    private int currCost;
    public int costIncPerS = 1;

    private float lastCostIncTime = 0f;

    [Space]
    [Header("以下内容请勿更改")]
    //游戏场景绑定-供其他类调用
    public GameObject birthDoor;
    public GameObject deadDoor;

    public Vector3 originalPos;
    public Vector3 targetPos;

    public const string TAG_BIRTHDOOR = "Respawn";
    public const string TAG_DEADDOOR = "Finish";

    private int playerScore = 3;


    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;

        birthDoor = GameObject.FindWithTag(TAG_BIRTHDOOR);
        deadDoor = GameObject.FindWithTag(TAG_DEADDOOR);

        originalPos = birthDoor.transform.position;
        targetPos = deadDoor.transform.position;
    }

    void Start()
    {
        InitPlayer();
    }


    // Update is called once per frame
    private void Update()
    {
        // TestGenerateHunter();

        IncCostPreS();
    }

    public void TestGenerateHunter()
    {
        if (Time.frameCount % 12000 == 1)
            HunterManager.instance.GenerateHunter(0, originalPos);
        if (Time.frameCount % 12000 == 8000)
            HunterManager.instance.GenerateHunter(1, originalPos);
        if (Time.frameCount % 12000 == 2000)
            HunterManager.instance.GenerateHunter(2, originalPos);

    }

    public void InitPlayer()
    {
        playerScore = 3;
        SetCurrCost(200);
    }
    public void LoseScore()
    {
        if (playerScore > 0)
        {
            playerScore -= 1;
            if (playerScore == 0)
                Debug.Log("游戏结束");
        }
    }

    public void CutCost(int cost)
    {
        SetCurrCost(currCost - cost);
    }

    public void AddCost(int cost)
    {
        if (cost <= 0)
            return;
        SetCurrCost(currCost + cost);

    }
    public int GetCurrCost() { return currCost; }

    private void SetCurrCost(int cost)
    {
        //currCost = Math.Min(Math.Max(cost, 0), totalCost);
        currCost = (cost > totalCost) ? totalCost : (cost < 0 ? 0 : cost);

        // display current cost
        if (UIManager.instance) UIManager.instance.DisplayCurrCost(currCost);
        else Debug.Log("GameManager ： Null UI Manager.");
    }

    private void IncCostPreS()
    {
        float currTime = TimeManager.instance.GetCurrTime();
        if (TimeManager.instance.GetCurrTime() - lastCostIncTime >= 1.0f)
        {
            SetCurrCost(currCost + costIncPerS);
            lastCostIncTime = currTime;
        }
    }

    public void UpdateDisplayer(GameObject go, string component)
    {
        //TODO
    }
}