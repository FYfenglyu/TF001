using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleTagedBuff : ScheduledBuff
{
    [Header("攻击对象标签")]
    public List<string> targetTags;

    private GameObject buffOwner;

    public override void Perform()
    {
        buffOwner = transform.parent.gameObject;

        if(!isEffectiveTo(buffOwner)) Destroy(this);

        base.Perform();
    }

    protected bool isEffectiveTo(GameObject owner)
    {
        Debug.Log(new string("Their Tag: ")+ owner.tag);
        return immuTags.Contains(owner.tag);
    }
}