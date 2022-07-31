using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ConstantTable;

public class CircleRangeAttack : MonoBehaviour
{
    [Header("圆形范围攻击的时间")]
    public float attackDuration = 0.01f;

    [Header("最多攻击次数")]
    public int maxAttakTimes = 3;
    protected int currAttackTimes = 0;

    protected float lastAttackBeginTime;

    protected CircleCollider2D circleRangeBox;
    protected Missile attacker;

    protected bool triggered = false;

    protected void Awake()
    {
        GetAndSetAttackBox();

        // get attacker
        attacker = GetComponentInParent<Missile>();

        // add delegation
        attacker.Attack += OnAttack;
    }

    public void OnAttack()
    {
        // if there are no more attack times, return
        if(++currAttackTimes>maxAttakTimes) return;
        Debug.Log(new string("Circle Attack Times: ")+currAttackTimes.ToString());

        lastAttackBeginTime = TimeManager.instance.GetCurrTime();
        SetTriggerBoxStatus(true);
    }

    protected void SetTriggerBoxStatus(bool status)
    {
        if(circleRangeBox) circleRangeBox.enabled = status;
    }

    protected void GetAndSetAttackBox()
    {
        // get attack range boxs and disable it
        circleRangeBox = GetComponent<CircleCollider2D>();

        if (circleRangeBox == null)
        {
            Debug.Log("Circle Range Attack Need a CircleCollider2D Component.");
            GameObject.Destroy(gameObject);
            return;
        }

        circleRangeBox.enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(TimeManager.instance.GetCurrTime()-lastAttackBeginTime>attackDuration)
        {
            SetTriggerBoxStatus(false);
            return;
        }

        OnCircleRangeAttack(other);
    }

    public virtual void OnCircleRangeAttack(Collider2D other) {}
}

