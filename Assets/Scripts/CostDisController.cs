using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostDisController : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Text>().text = GameManager.instance.GetCurrCost().ToString();
    }
}