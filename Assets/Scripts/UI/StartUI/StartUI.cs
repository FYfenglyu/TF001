using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ConstantTable;
public class StartUI : MonoBehaviour
{
    public static StartUI instance;
    private AudioSource audioSource;
    private AudioClip click_Audio;

    private void Awake() {
        audioSource = GameObject.Find("GameManager").GetComponent<AudioSource>();
        click_Audio = Resources.Load<AudioClip>(AUDIO_CLICKBUTTON);
    }
    
    public void SelectStart()
    {
        audioSource.PlayOneShot(click_Audio);
        GameManager.instance.LoadScene("Game@LevelSelect");
    }

    public void SelectHelp()
    {
        audioSource.PlayOneShot(click_Audio);
        GameManager.instance.LoadScene("helper");
    }

    public void SelectExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
