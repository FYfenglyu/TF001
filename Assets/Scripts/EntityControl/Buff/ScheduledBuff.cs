using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduledBuff : BuffBase
{
    [Header("Buff执行时间间隔")]
    public float interval = 1;
    protected float lastPerformTime = 0;

    private bool isWorking = false;

    [Header("Buff最多执行的次数")]
    public int maxPerformTimes = 100;

    public void CopyBuffTo(ScheduledBuff targetBuff)
    {
        targetBuff.interval = interval;
        targetBuff.lastPerformTime = lastPerformTime;
        targetBuff.isWorking = isWorking;
        targetBuff.maxPerformTimes = maxPerformTimes;
        base.CopyBuffTo(targetBuff);
    }

    public virtual void OnBuffStart() { }
    public virtual void OnBuffUpdate() { }
    public virtual void OnBuffDestroy() { }

    public override void Perform()
    {
        isWorking = true;
        startTime = TimeManager.instance.GetCurrTime();
        OnBuffStart();
    }

    // Template Pattern
    private void Update()
    {
        if (!isWorking) return;

        float currTime = TimeManager.instance.GetCurrTime();
        if (currTime - lastPerformTime < interval) return;
        if (currTime - startTime >= duration)
        {
            Destroy(this);
        }

        lastPerformTime = currTime;

        if (--maxPerformTimes < 0) return;

        OnBuffUpdate();
    }

    private void OnDestroy()
    {
        if (!isWorking) return;

        OnBuffDestroy();
    }
}