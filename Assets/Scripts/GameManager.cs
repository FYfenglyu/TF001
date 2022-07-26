using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // singleton

    [Header("全局总费用")]
    public int totalCost = 100;   // const?

    [Header("每秒回复的费用")]
    public int costIncPreSencond;

    [Space]
    [Header("以下内容请勿更改")]
    //游戏场景绑定-供其他类调用
    public GameObject birthDoor;
    public GameObject deadDoor;

    public Vector3 originalPos;
    public Vector3 targetPos;

    public const string TAG_BIRTHDOOR = "Respawn";
    public const string TAG_DEADDOOR = "Finish";

    private int playerScore =  3;
    private int currCost;

    private GameObject currProjectile;

    private Transform anchorPos;


    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;

        birthDoor = GameObject.FindWithTag(TAG_BIRTHDOOR);
        deadDoor = GameObject.FindWithTag(TAG_DEADDOOR);

        originalPos = birthDoor.transform.position;
        targetPos = deadDoor.transform.position;

        InitPlayer();

        anchorPos = GameObject.Find("AnchorPoint").transform;
    }

    // essential components

    // private Hunter[] HunterList;    // Hunters (undo)
    // private Projectile[] ProjectileList; // Projectiles (undo)

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        TestGenerateHunter();

    }

    private void FixedUpdate()
    {
        // update cost per sencond
        // currCost = (currCost + costIncPreSencond > totalCost) ? currCost + costIncPreSencond : currCost;

        // Debug.Log("Update per second.");
    }
    public void TestGenerateHunter()
    {
        if(Time.frameCount % 8000 == 1)
            HunterManager.instance.GenerateHunter(0, originalPos);
        if(Time.frameCount % 8000 == 4000)
            HunterManager.instance.GenerateHunter(1, originalPos);
        if(Time.frameCount % 8000 == 2000)
            HunterManager.instance.GenerateHunter(2, originalPos);
    
    }

    public void InitPlayer()
    {
        playerScore = 3;
        currCost = totalCost;
    }
    public void LoseScore()
    {
        if(playerScore > 0)
        {
            playerScore -= 1;
            if(playerScore == 0)
                print("游戏结束");
        }
    }

    public void CutCost(int cost)
    {
        cost = currCost - cost;
        currCost = (cost > totalCost) ? totalCost : (cost < 0 ? 0 : cost);

        // display current cost
        UIManager.instance.DisplayCurrCost(currCost);
    }

    public int GetCurrCost() { return currCost; }

    public void SetCurrProjectile(GameObject projectilePrefab)
    {
        // if there exists a projectile, destroy it
        if(currProjectile)
        {
            GameObject.Destroy(currProjectile);
        }

        // create a specified projectile
        currProjectile = GameObject.Instantiate(projectilePrefab, anchorPos);
    }
}