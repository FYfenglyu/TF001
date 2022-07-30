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
        AdjustScreeScale();
    }

    private void AdjustScreeScale()
    {
        // to edit
        float DevelopWidth = 1920f;
        float DevelopHeigh = 1080f;
        float DevelopRate = DevelopHeigh / DevelopWidth;
        int curScreenHeight = Screen.height;
        int curScreenWidth = Screen.width;

        Debug.Log(curScreenHeight);
        Debug.Log(curScreenWidth);

        float ScreenRate = (float)Screen.height / (float)Screen.width;

        float cameraRectHeightRate = DevelopHeigh / ((DevelopWidth / Screen.width) * Screen.height);
        float cameraRectWidthRate = DevelopWidth / ((DevelopHeigh / Screen.height) * Screen.width);

        if (DevelopRate <= ScreenRate)
        {
            GameObject.Find("MainCamera").GetComponent<Camera>().rect = new Rect(0, (1 - cameraRectHeightRate) / 2, 1, cameraRectHeightRate);
        }
        else
        {
            GameObject.Find("MainCamera").GetComponent<Camera>().rect = new Rect((1 - cameraRectWidthRate) / 2, 0, cameraRectWidthRate, 1);
        }
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