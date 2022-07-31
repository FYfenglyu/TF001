using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ConstantTable;

public class LevelSelectUI : MonoBehaviour
{
    private int currLevel = 1;

    private Sprite LevelButton_HightlightImage;
    private Sprite LevelButton_OnImage;
    private Sprite LevelButton_OffImage;
    private GameObject buttonsOn;
    private GameObject buttonsOff;

    void Awake() {
        // Load image of button icon
        LevelButton_HightlightImage = Resources.Load<Sprite>(GetLevelUIButtonImagePath("highlight"));
        LevelButton_OnImage = Resources.Load<Sprite>(GetLevelUIButtonImagePath("on"));
        LevelButton_OffImage = Resources.Load<Sprite>(GetLevelUIButtonImagePath("off"));
    
        // Find button parent-object in scene
        buttonsOn = GameObject.Find("button_on");
        buttonsOff = GameObject.Find("button_off");
        
    }

    void Start() {
        CheckLevelButton();    
    }
    public void CheckLevelButton()
    {
        RefreshCurrLevel();
        for(int i = 0; i < NUM_MAXLEVEL; ++i)
        {
            Transform buttonOn_i = buttonsOn.transform.GetChild(i);
            Transform buttonOff_i = buttonsOff.transform.GetChild(i);
            GameObject buttonOn_i_go =buttonOn_i.gameObject;
            GameObject buttonOff_i_go =buttonOff_i.gameObject;
            buttonOn_i.GetComponent<Button>().onClick.AddListener( delegate{SelectLevel(currLevel);} );
            if(i < currLevel-1)
            {
                buttonOn_i_go.SetActive(true);
                buttonOff_i_go.SetActive(false);
                OnCurrLevel(buttonOn_i_go);
            }
            else if (i == currLevel-1)
            {
                buttonOn_i_go.SetActive(true);
                buttonOff_i_go.SetActive(false);
                HighlightCurrLevel(buttonOn_i_go);
            }
            else
            {
                buttonOn_i_go.SetActive(false);
                buttonOff_i_go.SetActive(true);  
            }
        }
        ShowTrack(currLevel);
    }
    public int RefreshCurrLevel()
    {
        currLevel = GameManager.instance.currLevel;
        return currLevel;
    }

    public int SetCurrLevel(int nowLevel)
    {
        currLevel = nowLevel;
        return currLevel;
    }

    public void HighlightCurrLevel(GameObject thisButton)
    {
        thisButton.GetComponent<Image>().sprite = LevelButton_HightlightImage;
    }

    public void OnCurrLevel(GameObject thisButton)
    {
        thisButton.GetComponent<Image>().sprite = LevelButton_OnImage;
    }

    public void OffCurrLevel(GameObject thisButton)
    {
        thisButton.GetComponent<Image>().sprite = LevelButton_OffImage;
    }

    public void ShowTrack(int i)
    {}

    public void DarkCurrLevel()
    {}

    public void SelectLevel(int i)
    {
        GameManager.instance.LoadLevel(i);
    }

    public void SelectBack()
    {
        GameManager.instance.LoadScene(SCENE_START);
    }
}
