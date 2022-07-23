using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    
    [Header("怪物参数")]

    public float moveSpeed = 1.0f;
    public int healthPoint = 200;
    public int attack = 30;
    public int defence = 5;
    public int attackRange = 20; //可能需要乘上缩放系数

    //以上相关变量的操作应该分离，但现在还没分离

    //public float walkTime;

    [Space]
    public bool moving = true;

    [Space]
    [Header("其他设置")]

    //移速系数，每秒移动一个单位
    private float moveSpeedCoe;

    Vector2 dirLeft = Vector2.left;
    Vector2 dirRight = Vector2.right;
    // Start is called before the first frame update

    private static Vector3 OriginalPos;
    private static Vector3 TargetPos;

    private float roadDistance;
    private Rigidbody2D rb;


    void Start()
    {
        OriginalPos = transform.position;
        TargetPos = GameManager.instance.deadDoor.transform.position;
       // roadDistance = Vector3.Distance(deadDoor.transform.position, OriginalPos);
        if(moveSpeed <= 0.0f)
            moveSpeed = 1.0f;
       // walkTime = roadDistance / moveSpeed;
       
        rb = GetComponent<Rigidbody2D>();
        //最多存活90s
        Invoke(nameof(Dead), 90f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    //怪物的移动逻辑
    public void Move(bool goLeft)
    {
        transform.position += new Vector3(moveSpeed* Time.deltaTime * (goLeft?-1:1), 0);
        //清理屏外多余怪物
        if(transform.position.x < -20 )
            Dead();
    }

    public void Dead()
    {
        //清除Manager内列表信息
        MonsterManager.instance.monsters.Remove(this);
        Destroy(gameObject);
    }
    private void OnDestroy() {

    }

}
