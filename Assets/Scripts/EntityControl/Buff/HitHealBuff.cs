using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHealBuff : ScheduleTagedBuff
{
    [Header("攻击增加回血")]
    public int hitHeal = 50 ;

    public override void OnBuffStart()
    {
        if(owner) owner.buffImpact.hitHeal += hitHeal; 
    }

    public override void OnBuffDestroy()
    {
        if(owner) owner.buffImpact.hitHeal -= hitHeal; 
    }
}