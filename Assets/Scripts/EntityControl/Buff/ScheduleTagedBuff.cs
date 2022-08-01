using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ScheduleTagedBuff : ScheduledBuff
{
    [Header("针对类型进行附加")]
    public bool typeAttack;
    [Header("攻击对象标签")]
    public List<string> targetTypes;

    [Header("针对个体ID进行附加")]
    public bool monomerAttack;    
    [Header("允许附加的个体ID列表")]
    public List<int> targetIDs; 

    protected GameObject buffOwner;
    protected Lifebody owner;

    public void CopyBuffTo(ScheduleTagedBuff targetBuff)
    {
        targetBuff.typeAttack = typeAttack;
        targetBuff.targetTypes = new List<string>(targetTypes);
        targetBuff.monomerAttack = monomerAttack;
        targetBuff.targetIDs = new List<int>(targetIDs);

        base.CopyBuffTo(targetBuff);
    }

    public override void Perform()
    {
        buffOwner = transform.parent.gameObject;
        if(buffOwner) owner = buffOwner.GetComponent<Lifebody>();

                if(buffOwner) Debug.Log(buffOwner.tag);
        if(owner) Debug.Log(owner.id);
        Debug.Log(typeAttack?targetTypes.Contains(buffOwner.tag): 
                (monomerAttack?(owner&&targetIDs.Contains(owner.id)):false));


        if(!isEffective()) {Destroy(this);return;}

        base.Perform();
    }

    protected bool isEffective()
    {
        return typeAttack?targetTypes.Contains(buffOwner.tag): 
                (monomerAttack?(owner&&targetIDs.Contains(owner.id)):false);
    }
}