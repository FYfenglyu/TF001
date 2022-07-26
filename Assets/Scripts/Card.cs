using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // IPointerClickHandler

public class Card : MonoBehaviour, IPointerClickHandler
{
    [Header("投掷物卡牌ID")]
    public int projectileCardID;

    private ProjAttribute corrProjectileInfo;  // corresponding projectile information

    private void Start()
    {
        // load corresponding projectile information
        corrProjectileInfo = ProjectileData.instance.GetProjectileInfoByID(projectileCardID);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // get projectile card cost
        int cardCost = corrProjectileInfo.cost;

        // if card cost is higher than current cost, show related warnings
        if (cardCost > GameManager.instance.GetCurrCost())
        {
            // Debug.Log("Not Enough Cost.");
            // UIManager.TwinkCostDis();
            return;
        }

        // if card cost is lower than current cost or equal to current cost,
        // generate a projectile on card generate point
        // 1. get prefab with projectileCardID from projectileInfo
        // 2. let game manager generate corresponding instantiate
        GameObject projectilePrefab = (GameObject)Resources.Load(corrProjectileInfo.prefab);
        GameManager.instance.SetCurrProjectile(projectilePrefab);
    }
}
