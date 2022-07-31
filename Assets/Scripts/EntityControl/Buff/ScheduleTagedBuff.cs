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

    public override void Perform()
    {
        buffOwner = transform.parent.gameObject;
        if(buffOwner) owner = buffOwner.GetComponent<Lifebody>();

        if(!isEffective()) Destroy(this);
        if(owner) System.Console.WriteLine("Tag: {0}, ID : {1}",buffOwner.tag,owner.id);
        else System.Console.WriteLine("Tag: {0}, ID : {1}",buffOwner.tag,owner.id);

        base.Perform();
    }

    protected bool isEffective()
    {
        return typeAttack?targetTypes.Contains(buffOwner.tag):
        (monomerAttack?(owner&&targetIDs.Contains(owner.id)):false);
    }
}