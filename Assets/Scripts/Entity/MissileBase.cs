using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ConstantTable;

public class MissileBase : MonoBehaviour
{
    [Header("子弹种类")]
    public string missileType;
    public int id;

    [Header("子弹属性")]
    public int attack;
    public float attackRange;
    public float disapearVelocity;
    public int persistency; 

    [Space]
    protected ArrayList lbs = new ArrayList();
    protected bool isCollisied = false;
    protected bool isAttacked = false;
    protected Rigidbody2D rb;

    void Start() {
        InitParam();
    }

    protected virtual void InitParam()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void ClearSelf()
    {

        Destroy(gameObject);

    }

    public virtual void DestroySelf()
    {
        Destroy(gameObject);
    }


}
