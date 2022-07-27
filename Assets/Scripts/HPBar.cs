using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [Header("总血量")]
    public float totalHP = 100;

    private float currHP;

    private Image HPBarContImg;    // HP bar image

    // Start is called before the first frame update
    private void Start()
    {
        // get component
        HPBarContImg = transform.Find("HPBarContent").GetComponent<Image>();

        // set total HP as current HP
        SetCurrHP(totalHP);
    }

    private void Update()
    {
        MoveWithOwner();
    }

    private void MoveWithOwner()
    {

    }

    // set total health point
    private void SetTotalHp(float HP)
    {
        totalHP = HP;
    }

    // set the fillAmount of  HPBarContent to show current HP
    private void ShowCurrHP()
    {
        // set the fill amount of HP bar content
        float fillAmount = currHP / totalHP;
        HPBarContImg.fillAmount = fillAmount > 1 ? 1 : (fillAmount < 0 ? 0 : fillAmount);
    }

    // set current health point
    public void SetCurrHP(float HP)
    {
        currHP = (HP > totalHP) ? totalHP : (HP < 0 ? 0 : HP);
        ShowCurrHP();
    }

    // get current health point
    public float GetCurrHP() 
    {
        return currHP; 
    }
}
