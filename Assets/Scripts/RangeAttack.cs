using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{

    private string identity;
    private int attack;
    private float attackSpeed;
    private float attackRange;

    //攻速转换为时间间隔
    private float attackInterval;
    private float lastAttackTime;
    private GameObject attributeBody;
    // Start is called before the first frame update
    void Start()
    {
        Hunter try_hunter = gameObject.GetComponentInParent<Hunter>();
        if(try_hunter)
        {
            identity = ConstantTable.TYPE_HUNTER;
            attack = try_hunter.attack;
            attackSpeed = try_hunter.attackSpeed;
            attackRange = try_hunter.attackRange;
        }
        Guardian try_guardian = gameObject.GetComponentInParent<Guardian>();
        if(try_guardian)
        {
            identity = ConstantTable.TYPE_GUARDIAN;
            attack = try_guardian.attack;
            attackSpeed = try_guardian.attackSpeed;
            attackRange = try_guardian.attackRange; 
        }   
        Missile try_missile = gameObject.GetComponentInParent<Missile>();
        if(try_missile)
        {
            identity = ConstantTable.TYPE_MISSILE;
            attack = try_missile.attack;
            attackSpeed = 0;
            attackRange = try_missile.attackRange;
        }

        //计算时间间隔
        attackSpeed = Mathf.Max(attackSpeed, 0.02f);
        attackSpeed = Mathf.Min(attackSpeed, 50);
        attackInterval = 1 / attackSpeed;
        lastAttackTime = TimeManager.instance.GetTimeSecond();
        Debug.Log(attackInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    } 
    
    private void OnTriggerStay2D(Collider2D other) {
        GameObject go = other.gameObject;
        if(TimeManager.instance.GetTimeSecond() - lastAttackTime > attackInterval)
        {
            if(identity == ConstantTable.TYPE_HUNTER)
            {
                if(go.tag.Equals(ConstantTable.TYPE_GUARDIAN) )
                {
                    Debug.Log(TimeManager.instance.GetTimeSecond().ToString() + " :" + identity + "触发！" + lastAttackTime.ToString());
                    Guardian injuredGuardian = go.GetComponent<Guardian>(); 
                    injuredGuardian.CutHealthPoint(attack);
                    lastAttackTime = TimeManager.instance.GetTimeSecond();
                }
            
            }
            else if(identity == ConstantTable.TYPE_GUARDIAN)
            {
                if(go.tag.Equals(ConstantTable.TYPE_HUNTER))
                {
                    Debug.Log(TimeManager.instance.GetTimeSecond().ToString() + " :" + identity + "触发！" + lastAttackTime.ToString());
                    //发射子弹！
                    //Instantiate
                    //子弹动画！
                    //撞到人再扣血
                    //这里临时手动扣一下
                    Hunter injuredHunter = go.GetComponent<Hunter>(); 
                    injuredHunter.CutHealthPoint(attack);
                    lastAttackTime = TimeManager.instance.GetTimeSecond();

                }
            }
        }

    }
}
