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

    private int currCost;

    private void Awake()
    {
        instance = this;
        currCost = totalCost;
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

    }

    private void FixedUpdate()
    {
        // update cost per sencond
        // currCost = (currCost + costIncPreSencond > totalCost) ? currCost + costIncPreSencond : currCost;

        // Debug.Log("Update per second.");
    }

    public int getCurrCost() { return currCost; }

    public void setCurrCost(int cost) { currCost = (cost > totalCost) ? totalCost : (cost < 0 ? 0 : cost); }
}
