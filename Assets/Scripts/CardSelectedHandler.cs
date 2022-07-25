using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // IPointerClickHandler

public class CardSelectedHandler : MonoBehaviour, IPointerClickHandler
{
    [Header("投掷物卡牌ID")]
    public int projectileCardID;

    private Vector3 cardGenPos; // card generate point positon

    private ProjectileInfo corrProjectileInfo;  // corresponding projectile information

    private void Start()
    {
        // get card generate point positon
        cardGenPos = GameObject.Find("CardGenPos").transform.position;

        // load corresponding projectile information
        corrProjectileInfo = ProjectileInfoManager.instance.GetProjectileInfoByID(projectileCardID);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Debug.Log("Clicked.");

        // get projectile card cost
        int cardCost = corrProjectileInfo.cost;

        // if card cost is higher than current cost, show related warnings
        if (cardCost > GameManager.instance.getCurrCost())
        {
            // Debug.Log("Not Enough Cost.");

            return;
        }

        // if card cost is lower than current cost or equal to current cost,
        // generate a projectile on card generate point
        // 1. get prefab with projectileCardID from projectileInfo
        // 2. generate corresponding instantiate
        GameObject projectileEntity = (GameObject)Resources.Load(corrProjectileInfo.prefab);
        Instantiate(projectileEntity);
    }
}
