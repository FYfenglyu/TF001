using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private int totalHP = 100;

    private int currHP;

    private Image HPBarContImg;    // HP bar image
    private Text progressText;  // HP text

    private void Awake()
    {
        // get component
        HPBarContImg = transform.Find("HPBarContent").GetComponent<Image>();
        progressText = transform.Find("ProgressText").GetComponent<Text>();
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // set current health point
    public void SetTotalHP(int HP)
    {
        totalHP = HP;
        SetCurrHP(totalHP);
    }

    // set current health point
    public void SetCurrHP(int HP)
    {
        currHP = (HP > totalHP) ? totalHP : (HP < 0 ? 0 : HP);
        ShowCurrHP();
    }

    // set the fillAmount of  HPBarContent to show current HP
    private void ShowCurrHP()
    {
        // set the fill amount of HP bar content
        float fillAmount = (float)currHP / totalHP;
        HPBarContImg.fillAmount = fillAmount > 1 ? 1 : (fillAmount < 0 ? 0 : fillAmount);

        // set health point text
        string text = currHP.ToString() + new string("/") + totalHP.ToString();
        progressText.text = text;
    }
}
