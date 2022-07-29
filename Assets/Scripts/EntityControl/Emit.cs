using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using static ConstantTable;


public class Emit : MonoBehaviour
{
    [Header("发射设置")]
    public float moveSpeed;
    public Vector3 moveDirection;

    private bool isEmited = false;
    private Vector3 originalPos;
    private Vector3 disapearPos;

    
    [Header("发射配套组件")]
    protected Animator ator;

    public GameObject parent;

    void Awake() {
        ator = GetComponent<Animator>();        
    }

    void Start() {
        moveDirection = new Vector3(1f, -0.1f, 0f);
        AnimationBeginOn();
    }
    
    void FixedUpdate() {
        checkBeginFinish();
    }
    public bool checkBeginFinish()
    {
        if(ator.GetCurrentAnimatorStateInfo(0).IsName("forward"))
        {
            isEmited = true;
            MoveForward();  
            return true;
        }
        return false;
    }
    public void AnimationBeginOn()
    {
        if(ator && !isEmited)
        {    
            ator.SetBool("begin", true);
        }
    }
    public void AnimationBeginOff()
    {
        if(ator)
            ator.SetBool("begin", false);
    }

    public void AnimationEndOn()
    {
        if(ator)
        {
            ator.SetBool("end", true);
            ator.SetBool("begin", false);
        }
    }
    public void MoveForward()
    { 
        Move(moveSpeed *  moveDirection);
    }

    public void AddjustPosition()
    {
        transform.position += Vector3.right * 1.5f;

    }
    public void Move(Vector3 displacement)
    {
        transform.position += displacement;
    }
}
