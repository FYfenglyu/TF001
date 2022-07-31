using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpBuff : ScheduleTagedBuff
{
    [Header("移速增加百分比")]
    public float speedUpPercent = 50f ;

    public override void OnBuffStart()
    {
        if(owner) owner.buffImpact.speedRate *=(1.0f+speedUpPercent/100f); 
    }

    public override void OnBuffDestroy()
    {
        
        if(owner) owner.buffImpact.speedRate /=(1.0f+speedUpPercent/100f); 
    }
}