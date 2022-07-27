using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hunter : Lifebody
{
    [Header("怪物参数")]

    public float moveSpeed = 1.0f;

    private static Vector3 TargetPos;

    public Animator ator;

    // Start is called before the first frame update
    void Start()
    {
        
        TargetPos = GameManager.instance.deadDoor.transform.position;
        if(moveSpeed <= 0.0f)
            moveSpeed = 1.0f;
        ator = gameObject.GetComponent<Animator>();
        //最多存活90s
        Invoke(nameof(Dead), 90f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //重载了Move，为了保持和以前的接口一致
    public void Move(bool goLeft)
    {
        if (!isFreezed)
        {
            ator.SetBool("walk",true);
            Move(new Vector3(moveSpeed* Time.deltaTime * (goLeft?-1:1), 0));
            //清理屏外多余怪物
            if (transform.position.x < -20)
                Dead();
        }

    }
    public override void Still()
    {
        base.Still();
        //rb.isKinematic = true;
        ator.SetBool("walk",false);

    }

    public override void Unstill()
    {
        base.Unstill();
        rb.isKinematic = false;
    }
    public override void Dead()
    {
        //清除Manager内列表信息
        HunterManager.instance.hunters.Remove(this);
        Destroy(gameObject);
    }
}
