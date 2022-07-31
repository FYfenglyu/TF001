using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduledBuff : BuffBase
{
    [Header("Buff执行时间间隔")]
    public float interval = 1 ;
    public float lastPerformTime = 0;

    public bool isWorking = false;

    public int maxPerformTimes = 100;

    public virtual void OnBuffStart() {}
    public virtual void OnBuffUpdate() {}
    public virtual void OnBuffDestroy() {}

    private void Start()
    {
    }

    public override void Perform()
    {
        isWorking=true;
        startTime = TimeManager.instance.GetCurrTime();
    }

    // Template Pattern
    private void Update()
    {
        if(!isWorking) return;

        float currTime = TimeManager.instance.GetCurrTime();
        if(currTime-lastPerformTime<interval) return;
        if(currTime-startTime>=duration)
        {
            GameObject.Destroy(gameObject);
        }

        lastPerformTime=currTime;

        if(--maxPerformTimes<0) return;

        OnBuffUpdate();
    }

    private void OnDestroy()
    {
        if(!isWorking) return;
        
        OnBuffDestroy();
    }
}