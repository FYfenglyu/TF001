using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private GameObject costDisplayer;
    private GameObject cardScrollView;    // Scroll View 


    private UIManager() {}

    private void Awake()
    {
        instance = this;
        cardScrollView = GameObject.Find("CardScrollView");
        costDisplayer = GameObject.Find("CostDisplayer");        
    }

    private void Start()
    {

    }

    public void DisplayCurrCost(int currCost)
    {
        costDisplayer.GetComponent<CostDisplayer>().DisplayCurrCost(currCost);
    }

    public void DisableCardScrollView()
    {
        cardScrollView.GetComponent<CardScrollView>().Hide();
    }

    public void EnableCardScrollView()
    {
        cardScrollView.GetComponent<CardScrollView>().Display();
    }
}