using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ConstantTable;

public class LevelSelectUI : MonoBehaviour
{
    public static LevelSelectUI instance;
    private int currLevel = 1;

    private Sprite LevelButton_HightlightImage;
    private Sprite LevelButton_OnImage;
    private Sprite LevelButton_OffImage;
    private GameObject buttonsOn;
    private GameObject buttonsOff;
    private GameObject track;
    private SpriteRenderer trackSpriteRenderer;

    void Awake() {
        instance = this;

        // Load image of button icon
        LevelButton_HightlightImage = Resources.Load<Sprite>(GetLevelUIButtonImagePath("highlight"));
        LevelButton_OnImage = Resources.Load<Sprite>(GetLevelUIButtonImagePath("on"));
        LevelButton_OffImage = Resources.Load<Sprite>(GetLevelUIButtonImagePath("off"));
    
        // Find button parent-object in scene
        buttonsOn = GameObject.Find("button_on");
        buttonsOff = GameObject.Find("button_off");
        
        track = GameObject.Find("Track");
        trackSpriteRenderer = track.GetComponent<SpriteRenderer>(); 
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
            AddListenerSelectLevel(buttonOn_i.GetComponent<Button>(), i);
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

    public void ShowTrack(int level)
    {
        if(level > 1 && level <= NUM_MAXLEVEL)
        {
            track.SetActive(true);
            string path = GetLevelTrackImagePath(level);
            Sprite newTrack = Resources.Load<Sprite>(path);
            trackSpriteRenderer.sprite = newTrack;
        }
        else if (level <= 1)
        {
            track.SetActive(false);
        }

    }
    public void DarkCurrLevel()
    {}

    public void AddListenerSelectLevel(Button b, int i)
    {
        b.onClick.AddListener( delegate{SelectLevel(i + 1);} );
    }
    public void SelectLevel(int i)
    {
        GameManager.instance.LoadLevel(i);
    }

    public void SelectBack()
    {
        GameManager.instance.LoadScene(SCENE_START);
    }

    
}
