using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpBuff : ScheduleTagedBuff
{
    [Header("移速增加百分比")]
    public float speedUpPercent = 50f ;

    public override void Perform()
    {
        base.Perform();
    }

    public override void OnBuffStart()
    {
        // spped down
        //(1+speedUpPercent/100)
    }

    public override void OnBuffDestroy()
    {
        // spped up
        //(1+speedUpPercent/100)
    }
}