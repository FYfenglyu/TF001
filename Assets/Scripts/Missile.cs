using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [Header("导弹属性")]
    public int cost;
    public int mid;

    [Space]
    public float dispearVelocity;

    [Header("战斗属性")]
    public int attack;
    public float attackRange;
    public string missileType;

    private ArrayList injuredHunters = new ArrayList();

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
        //碰撞后，速度小于0.5f秒则消失
        if(isCollisied)
        {
            float relativeVel = rigid.velocity.magnitude;
            //Debug.Log(relativeVel);
            if(relativeVel < dispearVelocity)
                SelfClear();
        }
    }

    private void OnCollisionStay2D(Collision2D other) {

        isCollisied = true;
        GameObject go = other.gameObject;
        Debug.Log("撞到了" + go.tag);
        if(go.tag.Equals(ConstantTable.TYPE_HUNTER) )
        {
            Hunter injuredHunter = go.GetComponent<Hunter>();
            if(injuredHunter && !injuredHunters.Contains(injuredHunter))
            {
                injuredHunter.CutHealthPoint(attack);
                injuredHunters.Add(injuredHunter);
            }

        }
        else if(go.tag.Equals(ConstantTable.TYPE_ROAD))
        {
            if(missileType.Equals(ConstantTable.TYPE_GUARDIAN))
            {
                //之后要能通过mid指定生成的守护者
                GameObject.Instantiate(Resources.Load<Guardian>("Guardian/elephant_GUA"), gameObject.transform.position, Quaternion.identity);
                SelfClear();
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
