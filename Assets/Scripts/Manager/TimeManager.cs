using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance; // singleton

    private float second = 0.0f; // time : second

    private void Awake()
    {
        instance = this;
    }

    void Update()
    { 
        second += Time.deltaTime;
    }

    // get time : second
    public float GetTimeSecond()
    {
        return second;
    }
}