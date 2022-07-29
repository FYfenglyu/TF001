using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
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
}