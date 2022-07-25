using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    // Scroll View 
    private GameObject CardScrollView;

    private UIManager() {}

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        CardScrollView = GameObject.Find("CardScrollView");
        CardScrollView.SetActive(false);
    }

    public void DisableCardScrollView()
    {
        // CardScrollView = transform.Find("CardScrollView");
        // CardScrollView.enabled = false;
    }
}