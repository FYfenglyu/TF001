using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickGH : MonoBehaviour {


    void Start () {
    
    }
    
    void Update () {
    
    }

    public void Clicked()
    {
        MonsterManager.instance.GenerateMonster(0, GameManager.instance.originalPos);
    }    
}