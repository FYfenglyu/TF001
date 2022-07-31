using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hunter : Lifebody
{
    [Header("怪物属性")]

    public float moveSpeed = 1.0f;

    private static Vector3 TargetPos;
    private bool isMoving = true;


    // Start is called before the first frame update
    void Start()
    {
        InitParam();
        TargetPos = PlayManager.instance.deadDoor.transform.position;
        if (moveSpeed <= 0.0f)
            moveSpeed = 1.0f;
        //最多存活90s
        Invoke(nameof(Dead), 90f);
    }

    private void FixedUpdate()
    {
        Move(true);
        ResetStatus();
    }

    public void Move(bool goLeft)
    {
        if (!isFreezed)
        {
            AnimateWalkOn();
            Move(new Vector3(moveSpeed * Time.deltaTime * (goLeft ? -1 : 1), 0));
            //清理屏外多余怪物
            if (transform.position.x < -20)
                Dead();
        }

    }
    public override void Still()
    {
        base.Still();
        rb.isKinematic = true;
        AnimateWalkOff();

    }

    public override void Unstill()
    {
        base.Unstill();
        rb.isKinematic = false;
        AnimateAttackOff();
    }

    public void StopMove()
    {
        isMoving = false;
    }
    public void KeepMove()
    {
        isMoving = true;
    }

    public override void Dead()
    {
        //清除Manager内列表信息
        HunterManager.instance.hunters.Remove(this);
        base.Dead();
    }
}
