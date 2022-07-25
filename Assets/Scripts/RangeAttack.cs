using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
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
            Hunter mons = m.GetComponent<Hunter>();
            if(mons)
                mons.Dead();

        }
    }
}
