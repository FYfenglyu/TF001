using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian : Lifebody
{
    [Header("守护者属性")]
    public int cost;
    public int gid;

    protected Vector3 emitPos;
    public GameObject missilePrefab;

    void Start() {
        InitParam();
        emitPos = transform.Find("EmitPoint").transform.position;    
    }
    public void EmitMissile()
    {
        if (TimeManager.instance.GetCurrTime() - lastAttackTime > attackInterval)
        {
            GameObject missile = GameObject.Instantiate(missilePrefab, emitPos, Quaternion.identity);
            missile.transform.SetParent(gameObject.transform);
            lastAttackTime = TimeManager.instance.GetCurrTime();
        }
    }
}
