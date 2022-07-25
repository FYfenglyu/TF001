using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickGH : MonoBehaviour {


    void Start () {
    
    }
    
    void Update () {
    
    }

    public void Clicked(int hid)
    {
        MonsterManager.instance.GenerateMonster(hid, GameManager.instance.originalPos);
    }    
}