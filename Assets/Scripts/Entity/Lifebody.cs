using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Lifebody : MonoBehaviour
{

    
    [Header("生命体参数")]
    public int healthPoint = 200;

    public int attack = 30;
    public float attackSpeed = 30;
    public float attackRange = 20; //交给预制件

    //public int defence = 0;

    [Space]

    [Header("其他设置")]

    protected static Vector3 OriginalPos;

    protected Rigidbody2D rb;

    protected bool nextStepStill = false;
    protected bool isFreezed = false;
    void Start()
    {
        OriginalPos = transform.position;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
    }


    public virtual void CutHealthPoint(int attack)
    {
        if(attack > 0)
        {
            healthPoint = Mathf.Max(0, healthPoint - attack);
        }

        //HPbar显示更新
        GameManager.instance.UpdateDisplayer(gameObject, ConstantTable.DIS_HPBAR);
        Debug.Log("受击生物血量" + healthPoint.ToString());
        if(healthPoint == 0)
        {
            Dead();
        }
    }

    public virtual void Move(Vector3 displacement)
    {
            transform.position += displacement;

    }
    public virtual void Dead()
    {
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

    private void OnDestroy() {

    }
}
