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
    private AudioSource audioSource;
    private AudioClip bgm_Audio;
    private AudioClip ui_Audio;
    private AudioClip project1_Audio;
    private AudioClip project2_Audio;
    private AudioClip hithunter_Audio;
    private AudioClip click_Audio;
    private AudioClip appear_Audio;
    private AudioClip success_Audio;
    private AudioClip fail_Audio;

    private AudioClip emit_Audio;

    private GameObject successprompt;
    private GameObject failprompt;

    private PlayUI() { }

    private void Awake()
    {
        instance = this;
        cardScrollView = GameObject.Find("CardScrollView");
        costDisplayer = GameObject.Find("CostDisplayer");

        // 音频控制
        audioSource = GameObject.Find("GameManager").GetComponent<AudioSource>();
        bgm_Audio = Resources.Load<AudioClip>(AUDIO_BGM);
        ui_Audio = Resources.Load<AudioClip>(AUDIO_SELECTCARD);
        project1_Audio = Resources.Load<AudioClip>(AUDIO_PROJECT_LIGHT);
        project2_Audio = Resources.Load<AudioClip>(AUDIO_PROJECT_MAGIC);
        hithunter_Audio = Resources.Load<AudioClip>(AUDIO_HITHUNTER);
        click_Audio = Resources.Load<AudioClip>(AUDIO_CLICKBUTTON);
        appear_Audio = Resources.Load<AudioClip>(AUDIO_HUNTERAPPER);
        emit_Audio = Resources.Load<AudioClip>(AUDIO_EMIT);
        success_Audio = Resources.Load<AudioClip>(AUDIO_SUCCESS);
        fail_Audio = Resources.Load<AudioClip>(AUDIO_FAILED);

        audioSource.clip = bgm_Audio;
        audioSource.Play();

        AdjustScreenScale();
    }

    public static void AdjustScreenScale()
    {
        // to edit
        float DevelopWidth = 1920f;
        float DevelopHeigh = 1080f;
        float DevelopRate = DevelopHeigh / DevelopWidth;
        int curScreenHeight = Screen.height;
        int curScreenWidth = Screen.width;

        float ScreenRate = (float)Screen.height / (float)Screen.width;

        float cameraRectHeightRate = DevelopHeigh / ((DevelopWidth / Screen.width) * Screen.height);
        float cameraRectWidthRate = DevelopWidth / ((DevelopHeigh / Screen.height) * Screen.width);

        if (DevelopRate <= ScreenRate)
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().rect = new Rect(0, (1 - cameraRectHeightRate) / 2, 1, cameraRectHeightRate);
        }
        else
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().rect = new Rect((1 - cameraRectWidthRate) / 2, 0, cameraRectWidthRate, 1);
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

    public void PauseGame()
    {
        audioSource.PlayOneShot(click_Audio);
        TimeManager.instance.Pause();
    }

    public void ContinueGame()
    {
        audioSource.PlayOneShot(click_Audio);
        TimeManager.instance.Continue();
    }

    public void BackLevelSelect()
    {
        audioSource.PlayOneShot(click_Audio);
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

    public void PlayAudio(string name)
    {
        switch (name)
        {
            case "CardSelected":
                audioSource.PlayOneShot(ui_Audio);
                break;
            case "Success":
                audioSource.PlayOneShot(success_Audio);
                break;
            case "Fail":
                audioSource.PlayOneShot(fail_Audio);
                break;
            case "project_guardian":
                audioSource.PlayOneShot(project2_Audio);
                break;
            case "project_missile":
                audioSource.PlayOneShot(project1_Audio);
                break;
            case "hit":
                audioSource.PlayOneShot(hithunter_Audio);
                break;
            case "emit":
                audioSource.PlayOneShot(emit_Audio);
                break;
        }
    }

    public void NextLevel()
    {
        GameManager.instance.ReloadLevel();
    }

    public void RetryThisLevel()
    {
        GameManager.instance.ReplayLevel();
    }
}