using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostDisplayer : MonoBehaviour
{
    private Text costText;

    private void Awake()
    {
        costText = GameObject.Find("CostText").GetComponent<Text>();        
    }

    public void DisplayCurrCost(int currCost)
    {
        costText.text = currCost.ToString();
    }
}