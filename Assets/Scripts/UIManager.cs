using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private GameObject CostDisplayer;
    private GameObject CardScrollView;    // Scroll View 


    private UIManager() {}

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        CardScrollView = GameObject.Find("CardScrollView");
        CostDisplayer = GameObject.Find("CostDisplayer");
    }

    public void DisplayCurrCost(int currCost)
    {
        CostDisplayer.GetComponent<Text>().text = currCost.ToString();
    }

    public void DisableCardScrollView()
    {
        CardScrollView.GetComponent<CardScrollView>().Hide();
    }

    public void EnableCardScrollView()
    {
        CardScrollView.GetComponent<CardScrollView>().Display();
    }
}