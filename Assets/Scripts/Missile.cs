using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [Header("导弹属性")]
    public float attack;
    public float attackRange;
    public int cost;
    public int mid;

    public string missileType;

    private bool isCollisied = false;
    private Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isCollisied)
        {
            float relativeVel = rigid.velocity.magnitude;
            print(relativeVel);
            if(relativeVel < 1*0.5f)
                SelfClear();
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        isCollisied = true;
        GameObject m = other.gameObject;
        print(m.tag);
        if(m.tag.Equals("Hunter") )
        {
            //TODO这边数值系统尚未做
            Hunter mons = m.GetComponent<Hunter>();
            if(mons)
                mons.Dead();

        }
        else if(m.tag.Equals("Road"))
        {
            if(missileType.Equals("Guardian"))
            {
                //之后要能通过mid指定生成的守护者
                GameObject.Instantiate(Resources.Load<Guardian>("Guardian/elephant_GUA"), gameObject.transform.position, Quaternion.identity);
            }
            //SelfClear();
        }
        else
        {

        }

    }

    private void SelfClear()
    {

        Destroy(gameObject);

    }
    private void OnDestroy() {

    }

    public int GetCost()
    {
        return cost;
    }
}
