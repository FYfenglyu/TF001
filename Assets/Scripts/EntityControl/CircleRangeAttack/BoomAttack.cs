using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ConstantTable;

public class BoomAttack : CircleRangeAttack
{
    public override void OnCircleRangeAttack(Collider2D other)
    {
        GameObject theAttacked = other.gameObject;
        if (theAttacked.tag == TYPE_HUNTER)
        {
            Hunter injuredHunter = theAttacked.GetComponent<Hunter>();
            injuredHunter.CutHealthPoint(attacker.attack);
        }
        else if (theAttacked.tag == TYPE_GUARDIAN)
        {
            
        }
    }
}