using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian : MonoBehaviour
{
    [Header("守护者属性")]
    public float attack;
    public float attackDistance; //前方距离 
    public float attackHigh;
    public float attackSpeed;

    public int healthPoint;
    public int cost;
    public int gid;

    private Vector3 selfPos;
    private Vector3 leftPoint;
    private Vector3 rightUpPoint;


    private float lastAttackTime;
    // Start is called before the first frame update
    void Start()
    {
        CountAttackRange();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //下面两个都是错误代码，舍弃
    private void CountAttackRange()
    {
        /*
        selfPos = gameObject.transform.position;
        selfPos.z = 0;
        leftPoint = selfPos;
        rightUpPoint = leftPoint + new Vector3(attackDistance, attackHigh, 0.0f); 
        */
    }

    private bool isInAttackRange(Vector3 target)
    {
        /*
        if(null == leftPoint)
            CountAttackRange();
        Debug.DrawLine(leftPoint, rightUpPoint, Color.red);
        if(target.x > leftPoint.x && target.y > rightUpPoint.y && target.x < rightUpPoint.x && target.y < rightUpPoint.y)
        {
            return true;
        }
        else
        {
            return false;
        }
        */
        return false;
    }
    private void AttackFront()
    {
        
    }

    private void OnCollisionStay2D(Collision2D other) {
        
    }
    private void OnDestroy() {

    }
}
