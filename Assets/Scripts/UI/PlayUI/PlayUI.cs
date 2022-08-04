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

    private GameObject playUI;
    private GameObject successPrompt;
    private GameObject failPrompt;

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

        // load play UI
        // playUI = GameObject.Find("Play");

        // // load success prompt and fail prompt
        // successPrompt = transform.Find("SuccessPrompt").gameObject;
        // failPrompt = transform.Find("FailedPrompt").gameObject;

        // // disable success prompt and fail prompt
        // successPrompt.SetActive(false);
        // failPrompt.SetActive(false);

        // GameObject.Find("Play").GetComponent<CanvasGroup>().interactable = false;
        // successprompt.SetActive(true);
        // successprompt.GetComponent<CanvasGroup>().interactable = true;
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

    public void PlayAudio(string name)
    {
        switch(name)
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