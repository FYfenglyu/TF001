using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    public static PlayManager instance; // singleton

    [Header("全局总费用")]
    public int totalCost = 1000;

    [Header("每秒回复的费用")]

    public int costIncPerS = 1;

    [Header("开局初始费用")]
    public int initCost = 50;
    private int currCost;
    private float lastCostIncTime = 0f;


    [Header("总分数（最大漏怪个数）")]
    public int totalScore = 3;

    [Space]
    [Header("以下内容请勿更改")]
    //游戏场景绑定-供其他类调用
    public GameObject birthDoor;
    public GameObject deadDoor;

    public Vector3 originalPos;
    public Vector3 targetPos;

    public const string TAG_BIRTHDOOR = "Respawn";
    public const string TAG_DEADDOOR = "Finish";

    public int playerScore;

    private ProgressBar scoreProgress;
    private ProgressBar hunterProgress;

    // 生命周期函数
    // Start is called before the first frame update
    private void Awake()
    {
        // if there exists an instance, destroy the unnecessary instance 
        if (instance)
        {
            GameObject.Destroy(gameObject);
            return;
        }

        instance = this;

        birthDoor = GameObject.FindWithTag(TAG_BIRTHDOOR);
        deadDoor = GameObject.FindWithTag(TAG_DEADDOOR);

        originalPos = birthDoor.transform.position;
        targetPos = deadDoor.transform.position;

        scoreProgress = GameObject.Find("ScoreProgress").GetComponent<ProgressBar>();
        hunterProgress = GameObject.Find("HunterProgress").GetComponent<ProgressBar>();
    }

    void Start()
    {
        playerScore = totalScore;
        scoreProgress.SetTotalHP(totalScore);
        SetCurrCost(initCost);
    }

    // Update is called once per frame
    private void Update()
    {
        IncCostPreSencond();
        RefreshHunterProgress();
        if (HunterManager.instance.AreHuntersAllDead() && playerScore > 0)
        {
            // Debug.Log("Game Over: Win.");
            SceneManager.LoadSceneAsync("Game@Win");
        }
    }

    public void ResetGameStatus(LevelConfig config)
    {
        // 费用重置
        currCost = initCost;  //config.initCost
        SetCurrCost(initCost);

        // 分数重置
        totalScore = 3;
        playerScore = totalScore;
        RefreshHunterProgress();
        RefreshScoreProgress();
        // 时间重置
        TimeManager.instance.ResetTime();
        lastCostIncTime = 0f;

        //清空猎人配置
        HunterManager.instance.ResetParam(config);

        //开始游戏计时
        TimeManager.instance.Continue();
    }

    // 游戏进度相关函数
    public void RefreshHunterProgress()
    {
        hunterProgress.SetCurrHP(HunterManager.instance.GetLeaveHunterNum());
        hunterProgress.SetTotalHP(HunterManager.instance.GetTotalHunterNum());
    }

    public void RefreshScoreProgress()
    {
        scoreProgress.SetTotalHP(totalScore);
        scoreProgress.SetCurrHP(playerScore);
    }

    // 分数相关函数
    public void LoseScore()
    {
        playerScore = (playerScore - 1 > 0) ? playerScore - 1 : 0;
        scoreProgress.SetCurrHP(playerScore);
        if (playerScore == 0) SceneManager.LoadSceneAsync("Game@Lose");
    }

    // 费用相关函数
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
        PlayUI.instance.DisplayCurrCost(currCost);
    }

    private void IncCostPreSencond()
    {
        float currTime = TimeManager.instance.GetCurrTime();
        if (TimeManager.instance.GetCurrTime() - lastCostIncTime >= 1.0f)
        {
            SetCurrCost(currCost + costIncPerS);
            lastCostIncTime = currTime;
        }
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

}