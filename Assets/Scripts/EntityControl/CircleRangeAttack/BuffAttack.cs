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
        BuffBase buff = other.gameObject.AddComponent(buffPattern.GetType()) as BuffBase;
        UnityEditorInternal.ComponentUtility.CopyComponent(buffPattern);
        UnityEditorInternal.ComponentUtility.PasteComponentValues(buff);
        buff.Perform();
    }
}