using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickGH : MonoBehaviour {


    void Start () {
    
    }
    
    void Update () {
    
    }

    public void GenerateHunter(int hid)
    {
        HunterManager.instance.GenerateHunter(hid, GameManager.instance.originalPos);
    }   

    public void Add100Cost()
    {
        GameManager.instance.AddCost(100);
    }
}