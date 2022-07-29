using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ConstantTable;

public class RangeAttack : MonoBehaviour
{

    private string identity;
    //攻速转换为时间间隔

    // Start is called before the first frame update
    void Start()
    {
        Hunter try_hunter = gameObject.GetComponentInParent<Hunter>();
        if (try_hunter)
        {
            identity = TYPE_HUNTER;
        }
        Guardian try_guardian = gameObject.GetComponentInParent<Guardian>();
        if (try_guardian)
        {
            identity = TYPE_GUARDIAN;
        }
        //计算时间间隔
<<<<<<< HEAD:Assets/Scripts/EntityControl/RangeAttack.cs
=======
        attackSpeed = Mathf.Max(attackSpeed, 0.02f);
        attackSpeed = Mathf.Min(attackSpeed, 50);
        attackInterval = 1 / attackSpeed;
        lastAttackTime = TimeManager.instance.GetCurrTime();
        Debug.Log(attackInterval);
>>>>>>> a9cee4b57ab92e7e1f9991c837356ab4cd7cab8f:Assets/Scripts/Entity/RangeAttack.cs
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        GameObject go = other.gameObject;
        //本人为猎人
        if (identity == TYPE_HUNTER)
        {
            //对方为守护者
            if (go.tag.Equals(TYPE_GUARDIAN))
            {
                Lifebody Lb = gameObject.GetComponentInParent<Lifebody>();
                Lb.Attack(go);
            }
        }
        //本人为守护者
        else if (identity == TYPE_GUARDIAN)
        {
            //对方为猎人
            if (go.tag.Equals(TYPE_HUNTER))
            {
<<<<<<< HEAD:Assets/Scripts/EntityControl/RangeAttack.cs
                gameObject.GetComponentInParent<Guardian>().EmitMissile();
            }
            else if (go.tag.Equals(TYPE_EMITMISSILE))
            {
=======
                if (TimeManager.instance.GetCurrTime() - lastAttackTime > attackInterval)
                {
                    //Debug.Log(TimeManager.instance.GetCurrTime().ToString() + " :" + identity + "触发！" + lastAttackTime.ToString());
                    //发射子弹！
                    //Instantiate
                    //子弹动画！
                    //撞到人再扣血
                    //这里临时手动扣一下
                    Hunter injuredHunter = go.GetComponent<Hunter>();
                    injuredHunter.CutHealthPoint(attack);
                    lastAttackTime = TimeManager.instance.GetCurrTime();
                }
>>>>>>> a9cee4b57ab92e7e1f9991c837356ab4cd7cab8f:Assets/Scripts/Entity/RangeAttack.cs
            }
        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {

        GameObject go = other.gameObject;
        if (identity == TYPE_HUNTER)
        {
            //对方为守护者
            if (go.tag.Equals(TYPE_GUARDIAN))
            {
                Lifebody Lb = gameObject.GetComponentInParent<Lifebody>();
                Lb.Unstill();

            }
        }
        else if (identity == TYPE_GUARDIAN)
        {
            if (go.tag.Equals(TYPE_EMITMISSILE))
            {
                if(go.transform.parent == gameObject.transform.parent)
                {
                    //暂时使用了missileBase而不是EmitMissile或者missile
                    go.GetComponent<MissileBase>().DestroySelf();
                }
            }
        }
    }
}
