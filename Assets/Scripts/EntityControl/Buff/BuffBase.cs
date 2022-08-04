using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BuffBase : MonoBehaviour
{
    [Header("Buff持续时间")]
    public float duration = 5f;
    protected float startTime = 0f;

    public virtual void CopyBuffTo(BuffBase targetBuff)
    {
        targetBuff.duration = duration;
        targetBuff.startTime = startTime;
    }

    public virtual void Perform() { }
}