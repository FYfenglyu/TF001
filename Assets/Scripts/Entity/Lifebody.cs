using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ConstantTable;


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

    protected static Vector3 OriginalPos;
    protected bool nextStepStill = false;
    protected bool isFreezed = false;
    protected float attackInterval;
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
        if (TimeManager.instance.GetCurrTime() - lastAttackTime > 1.1 * attackInterval)
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
        //自动获取种类
        if (tag == TYPE_GUARDIAN)
            lifebodyType = TYPE_GUARDIAN;
        else if (tag == TYPE_HUNTER)
            lifebodyType = TYPE_HUNTER;


        //计算时间间隔
        attackSpeed = Mathf.Max(attackSpeed, 0.02f);
        attackSpeed = Mathf.Min(attackSpeed, 50);
        attackInterval = 1 / attackSpeed;
        lastAttackTime = TimeManager.instance.GetCurrTime();
    }

    public virtual void CutHealthPoint(int attack)
    {
        if (attack > 0)
        {
            healthPoint = Mathf.Max(0, healthPoint - attack);

            // show it in focus
            UIManager.instance.SetObjectInFront(transform);
        }

        if (healthPoint == 0)
        {
            Dead();
        }
    }

    public virtual void Attack(GameObject injuredGo)
    {
        if (TimeManager.instance.GetCurrTime() - lastAttackTime > attackInterval)
        {
            //Debug.Log("attackInterval: " + attackInterval.ToString());
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
