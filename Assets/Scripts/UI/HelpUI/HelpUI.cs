using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ConstantTable;

public class HelpUI : MonoBehaviour
{
    public static HelpUI instance;
    private AudioSource audioSource;
    private AudioClip click_Audio;

    private void Awake() {
        audioSource = GameObject.Find("GameManager").GetComponent<AudioSource>();
        click_Audio = Resources.Load<AudioClip>(AUDIO_CLICKBUTTON);
    }
    
    public void BackStart()
    {
        audioSource.PlayOneShot(click_Audio);
        GameManager.instance.LoadScene("Game@Start");
    }

}
