using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ConstantTable;


public class BuffAttack : CircleRangeAttack
{
    [Header("攻击带有的Buff")]
    public List<BuffBase> buffBase = new List<BuffBase>();

    private BuffBase buffPattern;

    private void Start()
    {
        base.Awake();

        buffPattern = gameObject.GetComponent<BuffBase>();

        if (buffPattern) Debug.Log("OK");
    }

    public override void OnCircleRangeAttack(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        BuffBase buff = other.gameObject.AddComponent(buffPattern.GetType()) as BuffBase;

        Debug.Log("On Buff");

        // buff = buffPattern;

        // if(buff is ScheduleTagedBuff) {Debug.Log("111");((ScheduleTagedBuff)buffPattern).CopyBuffTo((ScheduleTagedBuff)buff);}
        // else if(buff is ScheduledBuff) {Debug.Log("222");((ScheduledBuff)buffPattern).CopyBuffTo((ScheduledBuff)buff);}
        // else if(buff is BuffBase) {Debug.Log("333");((BuffBase)buffPattern).CopyBuffTo((BuffBase)buff);}

        System.Reflection.FieldInfo[] fields = buffPattern.GetType().GetFields();
        foreach (System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(buff, field.GetValue(buffPattern));
        }
        buff.Perform();
    }
}