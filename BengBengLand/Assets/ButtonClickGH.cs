using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickGH : MonoBehaviour {


    void Start () {
    
    }
    
    void Update () {
    
    }

    public void Clicked(int mid)
    {
        MonsterManager.instance.GenerateMonster(mid, GameManager.instance.originalPos);
    }    
}