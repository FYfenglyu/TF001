using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarController : MonoBehaviour
{
    [Header("总血量")]
    public float totalHealthPoint = 100;

    private float currHealthPoint;

    // HP bar image
    private Image HPBarContent;

    // Start is called before the first frame update
    void Start()
    {
        currHealthPoint = totalHealthPoint;

        HPBarContent = transform.Find("HPBarContent").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        ShowCurrHealthPoint();
    }

    private void FixedUpdate()
    {
        SetCurrHealthPoint(GetCurrHealthPoint() - 1);
    }

    // set the fillAmount of  HPBarContent to show current HP
    private void ShowCurrHealthPoint()
    {
        HPBarContent.fillAmount = currHealthPoint / totalHealthPoint;
    }

    public void SetCurrHealthPoint(float currHP)
    {
        currHealthPoint = (currHP > totalHealthPoint) ? totalHealthPoint :(currHP < 0 ? 0 :currHP );
    }

        public float GetCurrHealthPoint()
    {
        return currHealthPoint;
    }
}
