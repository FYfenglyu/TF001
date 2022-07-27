using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian : MonoBehaviour
{
    [Header("守护者属性")]
    public int healthPoint;
    public int cost;
    public int gid;

    [Header("战斗属性")]
    public int attack;
    public float attackRange; //前方距离 
    public float attackHigh;
    public float attackSpeed;

    private Vector3 selfPos;
    private Vector3 leftPoint;
    private Vector3 rightUpPoint;


    private float lastAttackTime;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CutHealthPoint(int attack)
    {
        if (attack > 0)
        {
            healthPoint = Mathf.Max(0, healthPoint - attack);
        }

        //HPbar显示更新
        GameManager.instance.UpdateDisplayer(gameObject, ConstantTable.DIS_HPBAR);
        Debug.Log("受击守护者血量" + healthPoint.ToString());
        if (healthPoint == 0)
        {
            Dead();
        }
    }
    
    public void Dead()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {

    }
}
