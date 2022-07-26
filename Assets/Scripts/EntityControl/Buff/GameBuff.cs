using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBuff : ScheduledBuff
{
    [Header("cost每秒恢复增加")]
    public int costInc = 1;

    private void Awake()
    {
        base.Perform();
    }

    public override void OnBuffStart()
    {
        PlayManager.instance.costIncPerS += costInc;
    }

    public override void OnBuffDestroy()
    {
        GameObject.Destroy(gameObject);
        PlayManager.instance.costIncPerS -= costInc;
    }
}