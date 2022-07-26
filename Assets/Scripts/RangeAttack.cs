using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{

    private string identity;
    private int attack;
    private float attackSpeed;
    private float attackRange;


    private GameObject attributeBody;
    // Start is called before the first frame update
    void Start()
    {
        Hunter try_hunter = gameObject.GetComponent<Hunter>();
        if(try_hunter)
        {
            identity = ConstantTable.TYPE_HUNTER;
            attack = try_hunter.attack;
            attackSpeed = try_hunter.attackSpeed;
            attackRange = try_hunter.attackRange;
        }
        Guardian try_guardian = gameObject.GetComponent<Guardian>();
        if(try_guardian)
        {
            identity = ConstantTable.TYPE_GUARDIAN;
            attack = try_guardian.attack;
            attackSpeed = try_guardian.attackSpeed;
            attackRange = try_guardian.attackRange; 
        }   
        Missile try_missile = gameObject.GetComponent<Missile>();
        if(try_missile)
        {
            identity = ConstantTable.TYPE_MISSILE;
            attack = try_missile.attack;
            attackSpeed = 0;
            attackRange = try_missile.attackRange;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    } 
    
    private void OnCollisionStay2D(Collision2D other) {
        
        GameObject m = other.gameObject;
        Debug.Log(m.tag);
        if(m.tag.Equals("Hunter") )
        {
            //TODO这边数值系统尚未做
            Hunter mons = m.GetComponent<Hunter>();
            if(mons)
                mons.Dead();

        }
    }
}
