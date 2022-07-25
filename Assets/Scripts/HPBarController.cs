using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarController : MonoBehaviour
{
    [Header("总血量")]
    public float totalHP = 100;

    private float currHP;

    // HP bar image
    private Image HPBarContent;

    // Start is called before the first frame update
    void Start()
    {
        currHP = totalHP;

        HPBarContent = transform.Find("HPBarContent").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {

    }

    // set the fillAmount of  HPBarContent to show current HP
    private void ShowcurrHP()
    {
        HPBarContent.fillAmount = currHP / totalHP;
    }

    // set current health point
    public void SetcurrHP(float HP)
    {
        currHP = (HP > totalHP) ? totalHP :(HP < 0 ? 0 : HP );
        ShowcurrHP();
    }

    // get current health point
    public float GetcurrHP()
    {
        return currHP;
    }
}
