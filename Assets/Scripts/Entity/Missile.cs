using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ConstantTable;

public class Missile : MissileBase
{
    [Header("其他属性")]
    public int cost;

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
        if(persistency == PERS_VELOCITY && isCollisied)
        {
            float relativeVel = rb.velocity.magnitude;
            //Debug.Log(relativeVel);
            if(relativeVel < disapearVelocity)
                base.ClearSelf();
        }
        else if(persistency == PERS_TIME && isAttacked)
        {
            Invoke(nameof(base.ClearSelf), 10f);
        }
    }



    private void OnCollisionStay2D(Collision2D other) {

        GameObject go = other.gameObject;
        //对于守卫者
        if(missileType.Equals(TYPE_GUARDIAN))
        {
            if(go.tag.Equals(TYPE_ROAD))
            {
                //之后要能通过id指定生成的守护者
                Debug.Log("即将生成守卫者");
                GuardianManager.instance.GenerateGuardian(id, gameObject.transform.position, Quaternion.identity);
                DestroySelf();
            }
            else if(go.tag.Equals(TYPE_GUARDIAN))
            {
                go.GetComponent<Guardian>().Dead();
            }
        }
        //对普通攻击的导弹
        else
        {
            if(go.tag.Equals(TYPE_HUNTER) )
            {
                //要增加buff操作
                Lifebody lb = go.GetComponent<Lifebody>();
                if(lb && !lbs.Contains(lb))
                {   
                    Emit e = gameObject.GetComponent<Emit>();
                    if(e)
                        e.AnimationEndOn();
                    lb.CutHealthPoint(attack);
                    lbs.Add(lb);
                    isAttacked = true;
                }
            }
            
        }
        isCollisied = true;
    }

    public int GetCost()
    {
        return cost;
    }
}
