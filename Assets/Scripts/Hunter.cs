using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hunter : Lifebody
{
    [Header("怪物参数")]

    public float moveSpeed = 1.0f;

    private static Vector3 TargetPos;


    // Start is called before the first frame update
    void Start()
    {
        
        TargetPos = GameManager.instance.deadDoor.transform.position;
        if(moveSpeed <= 0.0f)
            moveSpeed = 1.0f;
       
        //最多存活90s
        Invoke(nameof(Dead), 90f);
    }

    // Update is called once per frame
    void Update()
    {
        if(nextStepStill)
        {    Still();
        }
    }

    //怪物的移动逻辑
    public override void Move(bool goLeft)
    {
        if(!isFreezed)
        {
            transform.position += new Vector3(moveSpeed* Time.deltaTime * (goLeft?-1:1), 0);
            //清理屏外多余怪物
            if(transform.position.x < -20 )
                Dead();
        }
    }
    public override void Dead()
    {
        //清除Manager内列表信息
        HunterManager.instance.hunters.Remove(this);
        Destroy(gameObject);
    }

}
