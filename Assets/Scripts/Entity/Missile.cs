using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ConstantTable;

public class Missile : MissileBase
{
    [Header("其他属性")]
    public int cost;

    // delegation
    public delegate void AttackAction();
    public AttackAction Attack;
    
    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        InitParam();
    }

    // Update is called once per frame
    void Update()
    {
        ClearSelf();
    }

    public override void ClearSelf()
    {
        //碰撞后，速度小于0.5f秒则消失
        if (persistency == PERS_VELOCITY && isCollisied)
        {
            if (rb.velocity.x < 0 || rb.velocity.magnitude < disapearVelocity)
            {
                Invoke(nameof(ClearBase), 0.12f);
            }
        }
        else if (persistency == PERS_TIME && isAttacked)
        {
            Invoke(nameof(ClearBase), 10f);
        }
    }

    private void ClearBase()
    {
        base.ClearSelf();
    }


    private void OnCollisionStay2D(Collision2D other)
    {
        GameObject go = other.gameObject;
        BorderClean(go);

        //对于守卫者
        if (missileType.Equals(TYPE_GUARDIAN))
        {
            if (go.tag.Equals(TYPE_ROAD))
            {
                //之后要能通过id指定生成的守护者
                GuardianManager.instance.GenerateGuardian(id, transform.position, Quaternion.identity);
                DestroySelf();
            }
            else if (go.tag.Equals(TYPE_GUARDIAN))
            {
                go.GetComponent<Guardian>().Dead();
            }
        }
        //守护者发出的导弹
        else if (missileType.Equals(TYPE_GUARDIANMISSILE))
        {
            if (go.tag.Equals(TYPE_HUNTER))
            {
                if (isAttacked) return;

                Lifebody lb = go.GetComponent<Lifebody>();

                if (lb)
                {
                    Emit e = gameObject.GetComponent<Emit>();
                    if (e)
                    {
                        e.AnimationEndOn();
                        lb.CutHealthPoint(attack);
                        isAttacked = true;
                    }
                }
            }
        }
        //对普通攻击的导弹
        else
        {
            Lifebody lb = go.GetComponent<Lifebody>();
            if (lb && !lbs.Contains(lb))
            {
                Attack();
                lbs.Add(lb);
                isAttacked = true;
            }
        }
        isCollisied = true;
    }

    public int GetCost()
    {
        return cost;
    }

    public void BorderClean(GameObject go)
    {
        if(go.tag.Equals(TYPE_DEADBORDER))
        {
            ClearBase();
        }
    }
}
