using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [Header("总血量")]
    public int totalHP = 100;

    [Header("血条对应角色")]
    public GameObject owner;

    [Header("血条与人物的y轴距离")]
    public float yDistance = 0.8f;

    private int currHP;

    private Image HPBarContImg;    // HP bar image    

    // Start is called before the first frame update
    private void Start()
    {
        // get component
        HPBarContImg = transform.Find("HPBarContent").GetComponent<Image>();

        // get owner and its health point
        owner = transform.parent.gameObject;
        totalHP = GetOwerHP();

        // set total HP as current HP
        SetCurrHP(totalHP);

        // get HP bars 
        // and set it as the parent of HP bar
        GameObject HPBars = GameObject.Find("HPBars");
        transform.SetParent(HPBars.transform, false);
    }


    private int GetOwerHP()
    {
        Lifebody lifebody = owner.GetComponent<Lifebody>();
        return lifebody.healthPoint;
    }

    private void Update()
    {
        MoveWithOwner();

        SetCurrHP(GetOwerHP());
    }

    private void MoveWithOwner()
    {
        if (owner)
        {
            transform.position = owner.transform.position + new Vector3(0, yDistance, 0);
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
    }

    // set the fillAmount of  HPBarContent to show current HP
    private void ShowCurrHP()
    {
        // set the fill amount of HP bar content
        float fillAmount = (float)currHP / totalHP;
        HPBarContImg.fillAmount = fillAmount > 1 ? 1 : (fillAmount < 0 ? 0 : fillAmount);
    }

    // set current health point
    public void SetCurrHP(int HP)
    {
        currHP = (HP > totalHP) ? totalHP : (HP < 0 ? 0 : HP);
        ShowCurrHP();
    }
}
