using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedUpBuff : ScheduleTagedBuff
{
    [Header("攻速增加百分比")]
    public float attackSpeedRate = 50f ;

    public override void OnBuffStart()
    {
        if(owner) owner.buffImpact.attackSpeedRate *= (1+attackSpeedRate/100f); 
    }

    public override void OnBuffDestroy()
    {
        if(owner==null) Debug.Log("Wrong");
        if(owner) owner.buffImpact.attackSpeedRate /= (1+attackSpeedRate/100f);
    }
}