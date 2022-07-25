using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadDoor : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject hunter;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        GameObject m = other.gameObject;
        Hunter mon = m.GetComponent<Hunter>();
        if( null != mon )
        {
            GameManager.instance.LoseScore();
            mon.Dead();
        }
    }
}
