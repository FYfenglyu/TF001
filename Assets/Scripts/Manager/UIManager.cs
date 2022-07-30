using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    private GameObject costDisplayer;
    private GameObject cardScrollView;    // Scroll View 


    private UIManager() { }

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

    public void StartGame()
    {
        SceneManager.LoadSceneAsync("SampleScene");
        Debug.Log("Start Game.");
    }

    public void PauseGame()
    {
        TimeManager.instance.Pause();
    }

    public void ContinueGame()
    {
        TimeManager.instance.Continue();
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void SetObjectInFront(Transform focus)
    {
        Transform parentGameObject = focus.parent;
        int siblingNum = parentGameObject.childCount;
        focus.SetSiblingIndex(siblingNum - 1);
    }
}