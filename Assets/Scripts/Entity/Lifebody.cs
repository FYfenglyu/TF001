using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ConstantTable;
using static CommonFunction;

public class BuffImpact
{
    public float speedRate = 1.0f;
    public int selfHeal = 0;
    public float attackSpeedRate = 1.0f;
    public int hitHeal = 0;
}

public class Lifebody : MonoBehaviour
{
    [Header("生命体种类")]
    public string lifebodyType;
    public int id;

    [Space]

    [Header("生命体参数")]
    public int healthPoint = 200;

    public int attack = 10;
    public float attackSpeed = 3;
    public float attackRange = 2; //交给预制件

    //public int defence = 0;

    [Space]
    [Header("生命体配套组件")]
    protected Animator ator;
    protected Rigidbody2D rb;

    [Header("其他设置")]
    // add simple buff
    public BuffImpact buffImpact = new BuffImpact();

    protected static Vector3 OriginalPos;
    protected bool nextStepStill = false;
    protected bool isFreezed = false;
    private float attackInterval;
    protected float lastAttackTime;

    public List<BuffBase> buffs;

    void Start()
    {
        InitParam();
    }

    private void FixedUpdate()
    {
        ResetStatus();
    }

    protected virtual void ResetStatus()
    {
        if (TimeManager.instance.GetCurrTime() - lastAttackTime > 1.1 * GetAttackInterval())
        {
            Unstill();
            AnimateWalkOn();
            AnimateAttackOff();
        }
        Stand();
    }
    protected virtual void InitParam()
    {
        OriginalPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        ator = GetComponent<Animator>();
        
        //计算时间间隔
        attackSpeed = Mathf.Max(attackSpeed, 0.02f);
        attackSpeed = Mathf.Min(attackSpeed, 50);
        GetAttackInterval();
        lastAttackTime = TimeManager.instance.GetCurrTime();
    }

    public float GetAttackInterval()
    {
        attackInterval = 1.0f /(attackSpeed*buffImpact.attackSpeedRate);
        return attackInterval;
    }

    public virtual void CutHealthPoint(int attack)
    {
        if (attack > 0)
        {
            healthPoint = Mathf.Max(0, healthPoint - attack);

            // show it in focus
            SetObjectInFront(transform);
        }

        if (healthPoint == 0)
        {
            Dead();
        }
    }

    public virtual void Attack(GameObject injuredGo)
    {
        if (TimeManager.instance.GetCurrTime() - lastAttackTime > GetAttackInterval())
        {
            Lifebody injuredLb = injuredGo.GetComponent<Lifebody>();
            injuredLb.CutHealthPoint(attack);
            lastAttackTime = TimeManager.instance.GetCurrTime();
            Still();
            if (ator)
                ator.SetBool("attack", true);
        }
    }

    public virtual void Move(Vector3 displacement)
    {
        displacement.x *= buffImpact.speedRate;
        transform.position += displacement;
    }

    public virtual void Dead()
    {
        if (gameObject)
            Destroy(gameObject);
    }

    public virtual void NextStepStill()
    {
        nextStepStill = true;
    }

    public virtual void Still()
    {
        isFreezed = true;
    }

    public virtual void Unstill()
    {
        isFreezed = false;
    }

    public virtual void Stand()
    {
        transform.rotation = Quaternion.identity;
    }
    protected virtual void AnimateAttackOn()
    {
        if (ator)
            ator.SetBool("attack", false);
    }
    protected virtual void AnimateWalkOn()
    {
        if (ator)
            ator.SetBool("walk", true);
    }
    protected virtual void AnimateAttackOff()
    {
        if (ator)
            ator.SetBool("attack", false);
    }
    protected virtual void AnimateWalkOff()
    {
        if (ator)
            ator.SetBool("walk", false);
    }

    private void OnDestroy()
    {

    }
}
