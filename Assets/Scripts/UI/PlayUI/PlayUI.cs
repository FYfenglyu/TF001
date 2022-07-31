using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static ConstantTable;

public class PlayUI : MonoBehaviour
{
    public static PlayUI instance;
    private GameObject costDisplayer;
    private GameObject cardScrollView;    // Scroll View 


    private PlayUI() { }

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

     public void PauseGame()
    {
        TimeManager.instance.Pause();
    }

    public void ContinueGame()
    {
        TimeManager.instance.Continue();
    }

    public void BackLevelSelect()
    {
        GameManager.instance.LoadScene(SCENE_LEVELSELECT);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }



}