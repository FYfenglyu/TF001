using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ConstantTable;

public class Guardian : Lifebody
{
    [Header("守护者属性")]
    public int cost;
    public int gid;

    protected Vector3 emitPos;
    public GameObject missilePrefab;

    void Start() {
        InitParam();
        lifebodyType = TYPE_GUARDIAN;
        emitPos = transform.Find("EmitPoint").transform.position;    
    }
    public void EmitMissile()
    {
        if (TimeManager.instance.GetCurrTime() - lastAttackTime > GetAttackInterval())
        {
            GameObject missile = GameObject.Instantiate(missilePrefab, emitPos, Quaternion.identity);
            missile.transform.SetParent(gameObject.transform);
            lastAttackTime = TimeManager.instance.GetCurrTime();
        }
    }
}
