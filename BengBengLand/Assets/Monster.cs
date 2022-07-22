using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    //public GameObject deadDoor;

    [Header("怪物参数")]

    public float moveSpeed = 8.0f;
    public int healthPoint = 200;
    public int attack = 30;
    public int defence = 5;
    
    public GameObject deadDoor;
    public float walkTime;

    [Space]

    Vector2 dirLeft = Vector2.left;
    Vector2 dirRight = Vector2.right;
    // Start is called before the first frame update

    private static Vector3 positionOriginal;
    private float roadDistance;
    void Start()
    {
        positionOriginal = transform.position;
        roadDistance = Vector3.Distance(deadDoor.transform.position, positionOriginal);
        if(moveSpeed <= 0.0f)
            moveSpeed = 1.0f;
        walkTime = roadDistance / moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Move(true);
    }

    //怪物的移动逻辑
    public void Move(bool goLeft)
    {
        if(transform.position.x <= deadDoor.transform.position.x)
        {
            Dead();
        }
        transform.position += new Vector3(moveSpeed* Time.deltaTime * (goLeft?-1:1), 0);
    }

    public void Dead()
    {
        Destroy(gameObject);
    }

}
