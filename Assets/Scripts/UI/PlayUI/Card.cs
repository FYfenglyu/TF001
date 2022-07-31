using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // IPointerClickHandler

public class Card : MonoBehaviour, IPointerClickHandler
{
    [Header("投掷物卡牌ID")]
    public int cardID;

    private ProjAttribute corrProjAttr;  // corresponding projectile information

    private Image iconImg;

    private bool isSelected = false;

    private void Start()
    {
        // load corresponding projectile information
        corrProjAttr = ProjectileData.instance.GetProjAttr(cardID);

        // get icon image
        iconImg = transform.Find("Icon").GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // get projectile card cost
        int cardCost = corrProjAttr.cost;

        // if card cost is higher than current cost, show related warnings
        if (cardCost > PlayManager.instance.GetCurrCost())
        {
            // Debug.Log("Not Enough Cost.");
            // PlayUI.TwinkCostDis();
            return;
        }

        // if card cost is lower than current cost or equal to current cost,
        // let projectile manager generate corresponding instantiate
        ProjectileManager.instance.SetCurrCard(isSelected ? null : this);
        PlayUI.instance.PlayAudio("CardSelected");
    }

    public void ChangeIconImgMaterial(Material material)
    {
        iconImg.material = material;  // attention : a bug here, disable it and i will fix it later
    }

    public ref bool IsSelected() { return ref isSelected; }
}
