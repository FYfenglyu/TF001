using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBuff : ScheduledBuff
{
    [Header("cost每秒恢复增加")]
    public int costInc = 1 ;

    public override void OnBuffStart()
    {
        GameManager.instance.costIncPerS+=costInc;
    }

    public override void OnBuffDestroy()
    {
        GameManager.instance.costIncPerS-=costInc;
    }
}