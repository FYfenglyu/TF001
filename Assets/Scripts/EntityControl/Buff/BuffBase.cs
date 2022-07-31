using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BuffBase : MonoBehaviour
{
    [Header("Buff持续时间")]
    public float duration = 5f;
    public float startTime = 0f;

    public virtual void Perform() {}

    // public List<string> immuneTypes;
}

// public class BuffManager
// {
//     List<BuffBase> buffList;

//     public void AddBuff(BuffBase buff)
//     {
//         buffList.Add(buff);
//     }

//     public void RemoveBuff(BuffBase buff)
//     {
//         buffList.Remove(buff);
//     }
// }

// public class EntityLogic:MonoBehaviour
// {
//     List<BuffBase> BuffList;
// }