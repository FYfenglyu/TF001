using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleImmuBuff : ScheduledBuff
{
    [Header("免疫对象标签")]
    public List<string> immuTags;

    public GameObject buffOwner;

    public override void Perform()
    {
        buffOwner = transform.parent.gameObject;

        if(!isEffectiveTo(buffOwner)) Destroy(this);

        base.Perform();
    }

    protected bool isEffectiveTo(GameObject owner)
    {
        Debug.Log(owner.tag);
        return immuTags.Contains(owner.tag);
    }
}