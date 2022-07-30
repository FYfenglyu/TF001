using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ConstantTable;

public class BoomAttack : MonoBehaviour
{
    [Header("圆形范围攻击的时间")]
    public float attackDuration = 0.1f;

    protected CircleCollider2D boomRangeBox;
    protected Missile attacker;

    protected bool triggered = false;

    private void Awake()
    {
        // get and set circle range attack box
        GetAndSetAttackBox();

        // get attacker
        attacker = GetComponentInParent<Missile>();
    }

    public void Attack()
    {
        if (triggered) return;

        triggered = true;
        SetTriggerStatus(true);
        Invoke("DisableTrigger", attackDuration);
    }

    private void GetAndSetAttackBox()
    {
        // get attack range boxs and disable it
        boomRangeBox = GetComponent<CircleCollider2D>();

        if (boomRangeBox == null)
        {
            Debug.Log("Circle Range Attack Need a CircleCollider2D Component.");
            return;
        }

        boomRangeBox.enabled = false;
    }

    private void SetTriggerStatus(bool status)
    {
        boomRangeBox.enabled = status;
    }

    private void DisableTrigger()
    {
        SetTriggerStatus(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // play animation

        GameObject theAttacked = other.gameObject;
        if (theAttacked.tag == TYPE_HUNTER)
        {
            Hunter injuredHunter = theAttacked.GetComponent<Hunter>();
            injuredHunter.CutHealthPoint(attacker.attack);
        }
        else if (theAttacked.tag == TYPE_GUARDIAN)
        {
            // Debug.Log("Boom on Guardian");
        }
    }
}