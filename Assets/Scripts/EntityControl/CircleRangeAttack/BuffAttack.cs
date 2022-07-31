using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ConstantTable;


public class BuffAttack : CircleRangeAttack
{
    [Header("攻击带有的Buff")]
    [SerializeField]
    // public List<BuffBase> buffBase = new List<BuffBase>();

    private BuffBase buffPattern;

    private void Start() {
        base.Awake();

        buffPattern = gameObject.GetComponent<BuffBase>();

        if(buffPattern) Debug.Log("OK");
    }

    public override void OnCircleRangeAttack(Collider2D other)
    {
        Debug.Log("Test Buff");
        BuffBase buff = other.gameObject.AddComponent(buffPattern.GetType()) as BuffBase;
        buff = buffPattern;
        buff.Perform();
    }
}