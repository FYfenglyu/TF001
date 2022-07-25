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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D other) {
        
        GameObject m = other.gameObject;
        print(m.tag);
        if(m.tag.Equals("Hunter") )
        {
            //TODO这边数值系统尚未做
            Monster mons = m.GetComponent<Monster>();
            if(mons)
                mons.Dead();

        }
        else if(m.tag.Equals("Road"))
        {
            if(missileType.Equals("Guardian"))
            {
                //之后要能通过mid指定生成的守护者
                GameObject.Instantiate(Resources.Load<Guardian>("prefabs/elephant01-gua"), gameObject.transform.position, Quaternion.identity);
            }
            SelfClear();
        }
        else
        {
            Invoke(nameof(SelfClear), 2f);
        }
    }

    private void SelfClear()
    {

        Destroy(gameObject);

    }
    private void OnDestroy() {

    }

}
