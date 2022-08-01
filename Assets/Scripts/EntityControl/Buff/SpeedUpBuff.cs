using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpBuff : ScheduleTagedBuff
{
    [Header("移速增加百分比")]
    public float speedUpPercent = 50f ;

    public void CopyBuffTo(SpeedUpBuff anoBuff)
    {
        speedUpPercent = anoBuff.speedUpPercent;

        base.CopyBuffTo(anoBuff);
    }

    public override void OnBuffStart()
    {
        if(owner) owner.buffImpact.speedRate *=(1.0f+speedUpPercent/100f); 
        if(owner) Debug.Log(owner.buffImpact.speedRate);
    }

    public override void OnBuffDestroy()
    {
        
        if(owner) owner.buffImpact.speedRate /=(1.0f+speedUpPercent/100f); 
        if(owner) Debug.Log(owner.buffImpact.speedRate);
    }
}